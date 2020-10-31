using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace fx2core
{
    public static class Program
    {
        public static void Main()
        {
            var core2fxlib = LoadLibrary("core2fxNE.dll");
            if (core2fxlib == null)
            {
                Console.Error.WriteLine("Make sure you compiled core2fx and copied all output files next to the fx2core app.");
                Console.ReadLine();
                return;
            }
            var preload_runtime = GetProcAddress(core2fxlib, "preload_runtime");
            var preloadRuntime = Marshal.GetDelegateForFunctionPointer<PreloadRuntime>(preload_runtime);
            Console.WriteLine(".NET Framework -> .NET Core");
            preloadRuntime();
            var my_core_runtime = GetProcAddress(core2fxlib, "MyCoreRoutine");
            var myCoreRuntime = Marshal.GetDelegateForFunctionPointer<MyCoreRoutine>(my_core_runtime);
            var result = myCoreRuntime();
            Console.WriteLine("Done = {0}", result);
            Console.ReadLine();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = false)]
        public delegate void PreloadRuntime();

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = false)]
        public delegate int MyCoreRoutine();
    }
}