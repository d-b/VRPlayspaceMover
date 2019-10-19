using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlmSharp;

namespace PlayspaceMover
{
    enum Pose
    {
        POSE_TPose,
        POSE_Sit1,
        POSE_Sit2,
        POSE_Sit3,
        POSE_SitDangle,
        POSE_Float,
        POSE_Lie
    };

    struct PosingOptions
    {
        public bool lockRotation;
        public bool lockPosition;
        public bool unlockHip;
        public bool enableUnlock;
    }

    public partial class Main : Form
    {
        Library.LogDelegate logDelegate;
        Library.UpdateDelegate updateDelegate;

        Pose currentPose = Pose.POSE_TPose;
        float currentTime = 0.0f;
        quat currentRotation;
        vec3 currentPosition;

        void Log(ulong level, string message)
        {
            logRichText.Invoke(new Action(() =>
            {
                logRichText.Select(logRichText.TextLength, 0);

                switch (level)
                {
                    case 0:
                        logRichText.SelectionColor = Color.White; break;
                    case 1:
                        logRichText.SelectionColor = Color.Yellow; break;
                    case 2:
                        logRichText.SelectionColor = Color.Red; break;

                    default:
                        logRichText.SelectionColor = Color.White; break;
                }

                logRichText.AppendText(message);
            }));
        }

        TrackerState Update(PlayState state)
        {
            currentTime += state.deltaTime;

            PosingOptions posingOptions = GetPosingOptions();
            bool unlockPlayer = (state.unlockPlayer != 0 && posingOptions.enableUnlock);

            if (currentRotation == null || currentPose == Pose.POSE_TPose || !posingOptions.lockRotation || unlockPlayer)
            {
                vec3 headRight = state.hmd.rot * new vec3(1, 0, 0); headRight.y = 0;
                currentRotation = Library.quatLookAtRH(headRight.Normalized, new vec3(0, 1, 0));
            }

            if (currentPosition == null || currentPose == Pose.POSE_TPose || !posingOptions.lockPosition || unlockPlayer)
                currentPosition = state.hmd.pos;

            return GenerateTrackerState(state, posingOptions.unlockHip);
        }

        private TrackerState GenerateTrackerState(PlayState state, bool unlockHip)
        {
            float bodyHeight = 1.7f;

            switch (currentPose)
            {
                case Pose.POSE_Sit1:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-3.5F, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = unlockHip ? calcHipRotation(state.hmd.pos, trackers.hip.pos) : currentRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight * 0.75F + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = currentPosition + down * bodyHeight * 0.75F + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }

                case Pose.POSE_Sit2:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-5, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = unlockHip ? calcHipRotation(state.hmd.pos, trackers.hip.pos) : currentRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight * 0.55f + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = currentPosition + down * bodyHeight * 0.55f + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }

                case Pose.POSE_Sit3:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-10, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = unlockHip ? calcHipRotation(state.hmd.pos, trackers.hip.pos) : currentRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight * 0.45f + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation * new quat(new vec3(0, 0, -1));
                        trackers.rfoot.pos = currentPosition + down * bodyHeight * 0.45f + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation * new quat(new vec3(0, 0, -1));
                        return trackers;
                    }

                case Pose.POSE_SitDangle:
                    {
                        float dangle = DangleFactor(currentTime, 2.0f);
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-3.5F, 0, 0);
                        vec3 footDangle = currentRotation * new vec3(1, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = unlockHip ? calcHipRotation(state.hmd.pos, trackers.hip.pos) : currentRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight * 0.75F + (footForward - footRight) * 0.17f + footDangle * dangle * 0.075f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = currentPosition + down * bodyHeight * 0.75F + (footForward + footRight) * 0.17f - footDangle * dangle * 0.075f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }

                case Pose.POSE_Float:
                    {
                        float dangle = DangleFactor(currentTime, 1.5f);
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-1f, 0, 0);
                        vec3 footDangle = currentRotation * new vec3(0, 1.0f, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = unlockHip ? calcHipRotation(state.hmd.pos, trackers.hip.pos) : currentRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight * 0.95f + (footForward - footRight) * 0.17f + footDangle * dangle * 0.025f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = currentPosition + down * bodyHeight * 0.95f + (footForward + footRight) * 0.17f - footDangle * dangle * 0.025f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }

                case Pose.POSE_Lie:
                    {
                        vec3 headRight = currentRotation * new vec3(0, 1, 0); headRight.x = 0; headRight.z = 0;
                        quat currentLieRotation = Library.quatLookAtRH(headRight.Normalized, new vec3(-1, 0, 0));

                        vec3 down = currentRotation * new vec3(0, 0, -1);
                        vec3 footRight = new vec3(0, -1, 0);
                        vec3 footForward = currentRotation * new vec3(-1, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentLieRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentLieRotation;
                        trackers.rfoot.pos = currentPosition + down * bodyHeight + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentLieRotation;
                        return trackers;
                    }

                default:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-1, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = currentPosition + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentRotation;
                        trackers.lfoot.pos = currentPosition + down * bodyHeight + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = currentPosition + down * bodyHeight + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }
            }
        }

        private quat calcHipRotation(vec3 hmd, vec3 hip)
        {
            return Library.rotation(new vec3(0, 1, 0), (hmd - hip).Normalized) * currentRotation;
        }

        private PosingOptions GetPosingOptions()
        {
            return (PosingOptions)Invoke(new Func<PosingOptions>(() =>
            {
                PosingOptions options = new PosingOptions();
                options.lockRotation = checkLockRotation.Checked;
                options.lockPosition = checkLockPosition.Checked;
                options.unlockHip = checkUnlockHip.Checked;
                options.enableUnlock = checkEnableUnlock.Checked;
                return options;
            }));
        }

        public Main()
        {
            InitializeComponent();
        }

        private float DangleFactor(float time, float duration)
        {
            float value = Math.Min(Math.Max(0.0f, (time % duration) / duration), 1.0f);
            if (value <= 0.5f) return (4.0f * value) - 1.0f;
            else return 3.0f - (4.0f * value);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Options options = new Options();
            options.leftButtonMask = 1 << 7;
            options.rightButtonMask = 1 << 7;
            options.resetButtonMask = 1 << 1;
            options.unlockButtonMask = 1 << 34 | 1 << 2;
            logDelegate = new Library.LogDelegate(Log);
            updateDelegate = new Library.UpdateDelegate(Update);
            Library.Init(logDelegate, updateDelegate, options);
        }

        private void buttonTPose_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_TPose;
        }

        private void buttonSit1_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_Sit1;
        }

        private void buttonSit2_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_Sit2;
        }

        private void buttonSit3_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_Sit3;
        }

        private void buttonFloat_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_Float;
        }
        private void buttonSitDangle_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_SitDangle;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread exitThread = new Thread(new ThreadStart(() => Library.Exit()));
            exitThread.Start(); while (!exitThread.Join(100)) Application.DoEvents();
        }
    }
}
