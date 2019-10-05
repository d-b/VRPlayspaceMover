using GlmSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlayspaceMover
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    struct Options
    {
        public ulong leftButtonMask;
        public ulong rightButtonMask;
        public ulong resetButtonMask;
        public ulong rotateButtonMask;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct DeviceState
    {
        public vec3 pos;
        public quat rot;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct PlayState
    {
        public float deltaTime;
        public ulong rotatePlayer;
        public DeviceState hmd;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct TrackerState
    {
        public DeviceState hip;
        public DeviceState lfoot;
        public DeviceState rfoot;
    };

    class Library
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void LogDelegate(ulong level, [MarshalAs(UnmanagedType.LPWStr)] string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate TrackerState UpdateDelegate(PlayState state);

        [DllImport("libplayspacemover.dll")]
        public static extern ulong Init(LogDelegate logDelegate, UpdateDelegate updateDelegate, Options options);

        [DllImport("libplayspacemover.dll")]
        public static extern ulong Configure(Options options);

        [DllImport("libplayspacemover.dll")]
        public static extern ulong Exit();
    }
}
