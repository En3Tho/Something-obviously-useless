using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    public static unsafe class PInvokes
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string entryPoint);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string moduleName);
    }

    public static unsafe class PInvokesS
    {
        [DllImport("kernel32.dll"), SuppressGCTransition]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string entryPoint);

        [DllImport("kernel32.dll"), SuppressGCTransition]
        public static extern IntPtr GetModuleHandle(string moduleName);
    }


    internal class SuppressGCTransitionAttribute : Attribute { }

    [MemoryDiagnoser]
    public class PInvokeBenchmark
    {
        [Benchmark]
        public void GetProcAddress()
        {
            PInvokes.GetProcAddress(PInvokes.GetModuleHandle("kernel32.dll"), "Beep");
        }

        [Benchmark]
        public void GetProcAddressSuppressed()
        {
            PInvokesS.GetProcAddress(PInvokesS.GetModuleHandle("kernel32.dll"), "Beep");
        }
    }
}