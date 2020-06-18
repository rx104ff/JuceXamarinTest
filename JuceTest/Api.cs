using System;
using System.Runtime.InteropServices;
using System.Text;

namespace JuceTest
{
    public class Api
    {
        [DllImport(Lib.Name, EntryPoint = "cocosjuce_start_test_tone")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool StartTestTone(double frequency, float amplitude);

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_stop_test_tone")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool StopTestTone();

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_suspend")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool Suspend();

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_resume")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool Resume();

        [DllImport(Lib.Name, EntryPoint = "cocosjuce_release")]
        public static extern void Release();

    }

    internal static class Lib
    {
        public const string Name = "__Internal";
    }
}
