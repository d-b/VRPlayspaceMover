using GlmSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlayspaceMover
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Options
    {
        public ulong leftButtonMask;
        public ulong rightButtonMask;
        public ulong resetButtonMask;
        public ulong unlockButtonMask;
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
        public ulong unlockPlayer;
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

        public static quat quatLookAtRH(vec3 direction, vec3 up)
        {
            mat3 result = new mat3();
            result.Column2 = -direction;
            result.Column0 = vec3.Cross(up, result.Column2);
            result.Column1 = vec3.Cross(result.Column2, result.Column0);
            return result.ToQuaternion;
        }

        public static quat rotation(vec3 orig, vec3 dest)
        {
            vec3 axis;
            float theta = vec3.Dot(orig, dest);

            if (theta >= 1.0f - Single.Epsilon)
                return new quat(0, 0, 0, 1);

            if (theta < -1.0f + Single.Epsilon)
            {
                axis = vec3.Cross(new vec3(0, 0, 1), orig);
                if (axis.LengthSqr < Single.Epsilon) // bad luck, they were parallel, try again!
                    axis = vec3.Cross(new vec3(1, 0, 0), orig);

                return quat.FromAxisAngle((float)Math.PI, axis.Normalized);
            }

            axis = vec3.Cross(orig, dest);
            float angle = orig.LengthSqr * dest.LengthSqr + theta;
            return new quat(axis.x, axis.y, axis.z, angle).NormalizedSafe;
        }
    }
}
