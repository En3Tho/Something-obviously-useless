module Gists.FSharp.Caches

open System
open System.Text.Json
open System.Threading.Tasks
open En3Tho.FSharp.Extensions
open Microsoft.Extensions.Caching.Memory
open Microsoft.Extensions.Options
open FSharp.Control.Tasks
open StackExchange.Redis

type ICache =
    abstract Set<'a, 'b> : key: 'a * value: 'b * ttl: TimeSpan -> ValueTask<bool>
    abstract Remove<'a> : key: 'a -> ValueTask<unit>
    abstract SetOrUpdate<'a, 'b> : key: 'a * value: 'b * ttl: TimeSpan -> ValueTask<unit>
    abstract SetOrUpdate<'a, 'b> : key: 'a * value: 'b -> ValueTask<unit>
    abstract Get<'a, 'b> : key: 'a -> ValueTask<ValueOption<'b>>
    inherit IAsyncDisposable

type InMemoryCache(innerCache: ICache voption) =
    let cache = new MemoryCache({ new IOptions<_> with member _.Value = MemoryCacheOptions() })
    interface ICache with
        member this.DisposeAsync() = unitVtask {
            match innerCache with
            | ValueSome innerCache ->
                do! innerCache.DisposeAsync()
            | _ -> ()
            cache.Dispose()
        }

        member this.Get(key) =
            match cache.TryGetValue<'b> key with
            | true, value -> ValueTask<_>(ValueSome value)
            | _ ->
                match innerCache with
                | ValueSome innerCache ->
                    innerCache.Get key
                | _ -> ValueTask<_>(ValueNone)

        member this.Set(key, value, ttl) = vtask {
            match innerCache with
            | ValueSome innerCache ->
                match! innerCache.Set(key, value, ttl) with
                | true ->
                    cache.Set(key, value, ttl) |> ignore
                    return true
                | false ->
                    return false
            | _ ->
                match cache.TryGetValue(key) with
                | true, _ ->
                    return false
                | _ ->
                    cache.Set(key, value, ttl) |> ignore
                    return true
        }

        member this.SetOrUpdate(key, value, ttl) = vtask {
            match innerCache with
            | ValueSome innerCache ->
                do! innerCache.SetOrUpdate(key, value, ttl)
            | _ ->()

            cache.Set(key, value, ttl) |> ignore
        }

        member this.SetOrUpdate(key, value) =
            (this :> ICache).SetOrUpdate(key, value, TimeSpan.Zero)

        member this.Remove(key) = vtask {
            match innerCache with
            | ValueSome innerCache ->
                do! innerCache.Remove(key)
            | _ ->
                ()
            cache.Remove(key)
        }

type RedisCache(redis: IDatabase, cachePrefix: string, jsonSerializerOptions: JsonSerializerOptions, innerCache: ICache voption) =

    let makeKey value = icast<_, RedisKey> (cachePrefix + JsonSerializer.Serialize(value, jsonSerializerOptions))
    let makeValue value = icast<_, RedisValue> (JsonSerializer.SerializeToUtf8Bytes(value, jsonSerializerOptions))

    interface ICache with
        member this.DisposeAsync() = unitVtask {
            match innerCache with
            | ValueSome innerCache ->
                do! innerCache.DisposeAsync()
            | _ -> ()
        }

        member this.Get(key) = vtask {
            let! redisValue = redis.StringGetAsync(makeKey key)
            if redisValue.IsNullOrEmpty then
                match innerCache with
                | ValueSome innerCache ->
                    return! innerCache.Get key
                | _ -> return ValueNone
            else
                let array = icast<_, byte[]> redisValue
                return JsonSerializer.Deserialize(ReadOnlySpan.fromArray array, jsonSerializerOptions) |> ValueSome
        }

        member this.Set(key, value, ttl) = vtask {
            match innerCache with
            | ValueSome innerCache ->
                match! innerCache.Set(key, value, ttl) with
                | true ->
                    do! redis.StringSetAsync(makeKey key, makeValue value, expiry = ttl) :> Task
                    return true
                | false ->
                    return false
            | _ ->
                let key = makeKey key
                match! redis.KeyExistsAsync(makeKey key) with
                | true ->
                    return false
                | _ ->
                    do! redis.StringSetAsync(makeKey key, makeValue value, expiry = ttl) :> Task
                    return true
        }

         member this.SetOrUpdate(key, value, ttl) = vtask {
            match innerCache with
            | ValueSome innerCache ->
                do! innerCache.SetOrUpdate(key, value, ttl)
            | _ ->()
            do! redis.StringSetAsync(makeKey key, makeValue value, expiry = ttl) :> Task
        }

        member this.SetOrUpdate(key, value) =
            (this :> ICache).SetOrUpdate(key, value, TimeSpan.Zero)

        member this.Remove(key) = vtask {
            do! redis.KeyDeleteAsync(makeKey key) :> Task
        }