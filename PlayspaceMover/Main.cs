using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        POSE_Lie,
    };

    public partial class Main : Form
    {
        Library.LogDelegate logDelegate;
        Library.UpdateDelegate updateDelegate;

        Pose currentPose = Pose.POSE_TPose;
        quat currentRotation;

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

        quat quatLookAtRH(vec3 direction, vec3 up)
        {
            mat3 result = new mat3();
            result.Column2 = -direction;
            result.Column0 = vec3.Cross(up, result.Column2);
            result.Column1 = vec3.Cross(result.Column2, result.Column0);
            return result.ToQuaternion;
        }

        TrackerState Update(PlayState state)
        {
            if (currentRotation == null || currentPose == Pose.POSE_TPose || state.rotatePlayer != 0)
            {
                vec3 headRight = state.hmd.rot * new vec3(1, 0, 0); headRight.y = 0;
                currentRotation = quatLookAtRH(headRight.Normalized, new vec3(0, 1, 0));
            }

            float bodyHeight = 1.7f;

            switch (currentPose)
            {
                case Pose.POSE_Sit1:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-3.5F, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = state.hmd.pos + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentRotation;
                        trackers.lfoot.pos = state.hmd.pos + down * bodyHeight * 0.75F + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = state.hmd.pos + down * bodyHeight * 0.75F + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }

                case Pose.POSE_Sit2:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-5, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = state.hmd.pos + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentRotation;
                        trackers.lfoot.pos = state.hmd.pos + down * bodyHeight * 0.55f + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = state.hmd.pos + down * bodyHeight * 0.55f + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }

                case Pose.POSE_Sit3:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-10, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = state.hmd.pos + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentRotation;
                        trackers.lfoot.pos = state.hmd.pos + down * bodyHeight * 0.45f + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation * new quat(new vec3(0, 0, -1));
                        trackers.rfoot.pos = state.hmd.pos + down * bodyHeight * 0.45f + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation * new quat(new vec3(0, 0, -1));
                        return trackers;
                    }

                case Pose.POSE_Lie:
                    {
                        vec3 headRight = state.hmd.rot * new vec3(0, 1, 0); headRight.x = 0; headRight.z = 0;
                        quat currentLieRotation = quatLookAtRH(headRight.Normalized, new vec3(-1, 0, 0));

                        vec3 down = currentRotation * new vec3(0, 0, -1);
                        vec3 footRight = new vec3(0, -1, 0);
                        vec3 footForward = currentRotation * new vec3(-1, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = state.hmd.pos + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentLieRotation;
                        trackers.lfoot.pos = state.hmd.pos + down * bodyHeight + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentLieRotation;
                        trackers.rfoot.pos = state.hmd.pos + down * bodyHeight + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentLieRotation;
                        return trackers;
                    }

                default:
                    {
                        vec3 down = new vec3(0, -1, 0);
                        vec3 footRight = currentRotation * new vec3(0, 0, 1);
                        vec3 footForward = currentRotation * new vec3(-1, 0, 0);

                        TrackerState trackers = new TrackerState();
                        trackers.hip.pos = state.hmd.pos + down * (bodyHeight / 2.0f);
                        trackers.hip.rot = currentRotation;
                        trackers.lfoot.pos = state.hmd.pos + down * bodyHeight + (footForward - footRight) * 0.17f;
                        trackers.lfoot.rot = currentRotation;
                        trackers.rfoot.pos = state.hmd.pos + down * bodyHeight + (footForward + footRight) * 0.17f;
                        trackers.rfoot.rot = currentRotation;
                        return trackers;
                    }
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Options options = new Options();
            options.leftButtonMask = 1 << 7;
            options.rightButtonMask = 1 << 7;
            options.resetButtonMask = 1 << 1;
            options.rotateButtonMask = 1 << 34 | 1 << 2;
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

        private void buttonLie_Click(object sender, EventArgs e)
        {
            currentPose = Pose.POSE_Lie;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Library.Exit();
        }
    }
}
