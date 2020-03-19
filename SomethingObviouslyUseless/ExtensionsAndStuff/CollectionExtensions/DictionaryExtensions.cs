using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ExtensionsAndStuff.CollectionExtensions
{
    public static class DictionaryExtensions
    {
#pragma warning disable CS8604, CS8714
        public static bool TryGetValueAs<TResult, TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, [MaybeNullWhen(false)] out TResult? result)
            where TResult : class where TValue : class
        {
            bool found = dictionary.TryGetValue(key, out var value);
            var (res, ret) = found && value is TResult tValue ? (tValue, true) : (default, false);
            result = res;
            return ret;
        }
#pragma warning restore CS8604, CS8714
        
#pragma warning disable CS8604, CS8714
        public static bool TryGetValueAs<TResult, TKey, TValue, TIntermediate>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue, TIntermediate> getter, [MaybeNullWhen(false)] out TResult? result)
            where TResult : class where TValue : class
        {
            bool found = dictionary.TryGetValue(key, out var value);
            var (res, ret) = found && getter(value) is TResult tValue ? (tValue, true) : (default, false);
            result = res;
            return ret;
        }
    }
#pragma warning restore CS8604, CS8714
}