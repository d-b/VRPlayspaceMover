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
    public partial class Main : Form
    {
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
            TrackerState trackers = new TrackerState();
            float bodyHeight = 1.7f;
            vec3 down = new vec3(0, -1, 0);
            vec3 headRight = state.hmd.rot * new vec3(1, 0, 0); headRight.y = 0;
            quat rotation = quatLookAtRH(headRight.Normalized, new vec3(0, 1, 0));
            vec3 footRight = rotation * new vec3(0, 0, 1);
            vec3 footForward = rotation * new vec3(-1, 0, 0);

            trackers.hip.pos = state.hmd.pos + down * (bodyHeight / 2.0f);
            trackers.hip.rot = rotation;
            trackers.lfoot.pos = state.hmd.pos + down * bodyHeight + (footForward - footRight) * 0.17f;
            trackers.lfoot.rot = rotation;
            trackers.rfoot.pos = state.hmd.pos + down * bodyHeight + (footForward + footRight) * 0.17f;
            trackers.rfoot.rot = rotation;
            return trackers;
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
            Library.Init(Log, Update, options);
        }
    }
}
