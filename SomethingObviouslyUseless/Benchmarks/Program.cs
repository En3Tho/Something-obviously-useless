using System;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;
using Benchmarks.Classes;
using ExtensionsAndStuff.HelperClasses.WorkflowHelpers;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<ContainsBenchmark>();

            var validResult = ValidationWorkflow(DoSomethingValidFinish, DoSomethingValid, DoSomethingValidNext);
            var validString = validResult.Value switch
            {
                Success<string> a => a.Value,
                Error<string> b   => b.Value
            };
            Console.WriteLine(validString);
            
            var invalidResult = ValidationWorkflow(DoSomethingValidFinish, DoSomethingValid, DoSomethingInvalid);
            var invalidString = invalidResult.Value switch
            {
                Success<string> a => a.Value,
                Error<string> b   => b.Value
            };
            Console.WriteLine(invalidString);
            
            Console.ReadLine();
        }

        public static Choice<Success<TSuccess>, Error<TError>> ValidationWorkflow<TSuccess, TError>(Func <Choice<Success<TSuccess>, Error<TError>>> resultBuilder,
            params Func<Choice<NextStep, Error<TError>>>[] validators)
        {
            foreach (var func in validators)
            {
                switch (func().Value)
                {
                    case NextStep _: continue;
                    case Error<TError> error: return new Choice<Success<TSuccess>, Error<TError>>(error); 
                }
            }

            return resultBuilder();
        }
        
        public static Choice<NextStep, Error<string>> DoSomethingValid() => new Choice<NextStep, Error<string>>(NextStep.Instance);
        public static Choice<NextStep, Error<string>> DoSomethingInvalid() => new Choice<NextStep, Error<string>>(new Error<string>("Not finished successfully"));
        public static Choice<NextStep, Error<string>> DoSomethingValidNext() => new Choice<NextStep, Error<string>>(NextStep.Instance);
        public static Choice<Success<string>, Error<string>> DoSomethingValidFinish() => new Choice<Success<string>, Error<string>>(new Success<string>("Finished successfully"));
    }
}
