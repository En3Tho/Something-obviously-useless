module En3Tho.FSharpExtensions.Record

open System
open System.Reflection
open System.Reflection.Emit

[<AbstractClass; Sealed>]
type private RecordChangesApplier<'a, 'b>() =
   static member generateApply() =
        let parameterTypeA = typeof<'a>
        let parameterTypeB = typeof<'b>
        let returnType = parameterTypeA

        let fieldsA = parameterTypeA.GetFields(BindingFlags.Instance ||| BindingFlags.NonPublic)
                      |> Array.filter(fun str -> str.Name.EndsWith "@")
        let propertiesA = parameterTypeA.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
        let propertiesB = parameterTypeB.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)

        if fieldsA.Length <> propertiesA.Length then
            invalidOp <| "Non-record type specified, properties and backing fields lengths do not match!"
        elif (propertiesB, propertiesA) ||> Seq.intersectBy (fun prop -> (prop.Name, prop.PropertyType)) |> Seq.length <> propertiesB.Length then
            invalidOp <| "Invalid type specified, properties and backing fields lengths do not match!"
        else
            let ctor = parameterTypeA.GetConstructors() |> Array.exactlyOne
            let ctorParams = ctor.GetParameters()

            let dynamicMethod = DynamicMethod("Apply", returnType, [| parameterTypeA; parameterTypeB |])
            let generator = dynamicMethod.GetILGenerator()

            for param in ctorParams do
                match propertiesB |> Array.tryFind (fun (prop : PropertyInfo) -> prop.Name.Equals(param.Name, StringComparison.OrdinalIgnoreCase)) with
                | Some prop -> let getProp = prop.GetMethod
                               let opCodesCall = if getProp.IsVirtual then OpCodes.Callvirt else OpCodes.Call
                               generator.Emit OpCodes.Ldarg_1
                               generator.Emit(opCodesCall, getProp)
                | None -> let fieldInfo = fieldsA |> Array.find (fun fld -> let span = fld.Name.AsSpan()
                                                                            let span = span.Slice(0, span.Length - 1)
                                                                            span.Equals(param.Name.AsSpan(), StringComparison.OrdinalIgnoreCase))
                          generator.Emit OpCodes.Ldarg_0
                          generator.Emit(OpCodes.Ldfld, fieldInfo)

            generator.Emit(OpCodes.Newobj, ctor)
            generator.Emit OpCodes.Ret

            dynamicMethod.CreateDelegate(typeof<Func<'a, 'b, 'a>>) :?> Func<'a, 'b, 'a>

   [<DefaultValue>]
   static val mutable private _Apply : Func<'a, 'b, 'a>
   static do
       RecordChangesApplier<'a, 'b>._Apply <- RecordChangesApplier<'a, 'b>.generateApply()
   static member ChangesApplier = RecordChangesApplier<'a, 'b>._Apply

let apply value changes = RecordChangesApplier.ChangesApplier.Invoke(value, changes)
let merge value changes = () // TODO: merge records - if != then apply.