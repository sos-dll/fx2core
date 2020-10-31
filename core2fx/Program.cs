using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace core2fx
{
    public static class CoreClass
    {
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        public static int MyCoreRoutine()
        {
            Console.WriteLine(".NET Core -> .NET Framework");
            return 5_00_00_02;
        }
    }
}