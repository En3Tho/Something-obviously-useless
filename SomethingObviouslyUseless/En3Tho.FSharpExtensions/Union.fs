module En3Tho.FSharpExtensions.Union

open System
open System.Reflection
open System.Reflection.Emit

[<AbstractClass; Sealed>]
type private TagGetter<'a>() =
   static member generateGetTag() =
        let parameterType = typeof<'a>
        let returnType = typeof<int>
        let tagPropertyInfo = parameterType.GetProperty("Tag", BindingFlags.Public ||| BindingFlags.Instance)
        if isNull tagPropertyInfo || tagPropertyInfo.PropertyType <> returnType || isNull tagPropertyInfo.GetMethod then
            invalidOp <| sprintf "Invalid type specified: %s" parameterType.FullName
        else
            let dynamicMethod = DynamicMethod("GetTag", returnType, [| parameterType |])
            let generator = dynamicMethod.GetILGenerator()
            generator.Emit(OpCodes.Ldarg_0)
            generator.Emit(OpCodes.Call, tagPropertyInfo.GetMethod)
            generator.Emit(OpCodes.Ret)
            dynamicMethod.CreateDelegate(typeof<Func<'a, int>>) :?> Func<'a, int>

   [<DefaultValue>]
   static val mutable private tagGetter : Func<'a, int>
   static do
       TagGetter<'a>.tagGetter <- TagGetter<'a>.generateGetTag()
   static member TagGetter = TagGetter<'a>.tagGetter

let getTag unionObj = TagGetter.TagGetter.Invoke unionObj