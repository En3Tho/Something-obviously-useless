[<AutoOpen>]
module MinimalApisWithPipelines.ServiceCollectionExtensions

open System.Text.Json.Serialization
open Microsoft.AspNetCore.Http.Json
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Options

type IServiceCollection with
    member this.AddFSharpJsonOptions() =
        this.AddSingleton<IOptions<JsonOptions>>(fun _ ->
        let options = JsonOptions()

        let converter = JsonFSharpConverter(JsonUnionEncoding.UnwrapSingleFieldCases
                                            ||| JsonUnionEncoding.UnwrapSingleCaseUnions
                                            ||| JsonUnionEncoding.UnwrapFieldlessTags
                                            ||| JsonUnionEncoding.UnwrapOption,
                                            allowOverride = true)
        options.SerializerOptions.Converters.Add(converter)

        { new IOptions<JsonOptions> with member this.Value = options })