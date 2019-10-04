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
        ulong leftButtonMask;
        ulong rightButtonMask;
        ulong leftTogglePhysicsMask;
        ulong rightTogglePhysicsMask;
        float bodyHeight;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Vector3
    {
        float x;
        float y;
        float z;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Quat
    {
        float x;
        float y;
        float z;
        float w;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct DeviceState
    {
        Vector3 pos;
        Quat rot;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct PlayState
    {
        float deltaTime;
        DeviceState hmd;
        DeviceState hip;
        DeviceState lfoot;
        DeviceState rfoot;
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct TrackerState
    {
        DeviceState hip;
        DeviceState lfoot;
        DeviceState rfoot;
    };

    class Library
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate TrackerState UpdateDelegate(PlayState state);

        [DllImport("libplayspacemover.dll")]
        public static extern ulong Init(UpdateDelegate updateDelegate, Options options);

        [DllImport("libplayspacemover.dll")]
        public static extern ulong Configure(Options options);

        [DllImport("libplayspacemover.dll")]
        public static extern ulong Exit();
    }
}
