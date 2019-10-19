namespace PlayspaceMover
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSitDangle = new System.Windows.Forms.Button();
            this.buttonFloat = new System.Windows.Forms.Button();
            this.buttonSit3 = new System.Windows.Forms.Button();
            this.buttonSit2 = new System.Windows.Forms.Button();
            this.buttonSit1 = new System.Windows.Forms.Button();
            this.buttonTPose = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkUnlockHip = new System.Windows.Forms.CheckBox();
            this.checkEnableUnlock = new System.Windows.Forms.CheckBox();
            this.checkLockPosition = new System.Windows.Forms.CheckBox();
            this.checkLockRotation = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.logRichText = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(824, 101);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 75);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Poses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSitDangle, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonFloat, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSit3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSit2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSit1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTPose, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 69);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSitDangle
            // 
            this.buttonSitDangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSitDangle.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSitDangle.Location = new System.Drawing.Point(539, 3);
            this.buttonSitDangle.Name = "buttonSitDangle";
            this.buttonSitDangle.Size = new System.Drawing.Size(128, 63);
            this.buttonSitDangle.TabIndex = 5;
            this.buttonSitDangle.Text = "Sit Dangle";
            this.buttonSitDangle.UseVisualStyleBackColor = true;
            this.buttonSitDangle.Click += new System.EventHandler(this.buttonSitDangle_Click);
            // 
            // buttonFloat
            // 
            this.buttonFloat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFloat.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFloat.Location = new System.Drawing.Point(673, 3);
            this.buttonFloat.Name = "buttonFloat";
            this.buttonFloat.Size = new System.Drawing.Size(134, 63);
            this.buttonFloat.TabIndex = 4;
            this.buttonFloat.Text = "Float";
            this.buttonFloat.UseVisualStyleBackColor = true;
            this.buttonFloat.Click += new System.EventHandler(this.buttonFloat_Click);
            // 
            // buttonSit3
            // 
            this.buttonSit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSit3.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSit3.Location = new System.Drawing.Point(405, 3);
            this.buttonSit3.Name = "buttonSit3";
            this.buttonSit3.Size = new System.Drawing.Size(128, 63);
            this.buttonSit3.TabIndex = 3;
            this.buttonSit3.Text = "Sit 3";
            this.buttonSit3.UseVisualStyleBackColor = true;
            this.buttonSit3.Click += new System.EventHandler(this.buttonSit3_Click);
            // 
            // buttonSit2
            // 
            this.buttonSit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSit2.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSit2.Location = new System.Drawing.Point(271, 3);
            this.buttonSit2.Name = "buttonSit2";
            this.buttonSit2.Size = new System.Drawing.Size(128, 63);
            this.buttonSit2.TabIndex = 2;
            this.buttonSit2.Text = "Sit 2";
            this.buttonSit2.UseVisualStyleBackColor = true;
            this.buttonSit2.Click += new System.EventHandler(this.buttonSit2_Click);
            // 
            // buttonSit1
            // 
            this.buttonSit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSit1.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSit1.Location = new System.Drawing.Point(137, 3);
            this.buttonSit1.Name = "buttonSit1";
            this.buttonSit1.Size = new System.Drawing.Size(128, 63);
            this.buttonSit1.TabIndex = 1;
            this.buttonSit1.Text = "Sit 1";
            this.buttonSit1.UseVisualStyleBackColor = true;
            this.buttonSit1.Click += new System.EventHandler(this.buttonSit1_Click);
            // 
            // buttonTPose
            // 
            this.buttonTPose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTPose.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTPose.Location = new System.Drawing.Point(3, 3);
            this.buttonTPose.Name = "buttonTPose";
            this.buttonTPose.Size = new System.Drawing.Size(128, 63);
            this.buttonTPose.TabIndex = 0;
            this.buttonTPose.Text = "T-Pose";
            this.buttonTPose.UseVisualStyleBackColor = true;
            this.buttonTPose.Click += new System.EventHandler(this.buttonTPose_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 75);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkUnlockHip);
            this.groupBox1.Controls.Add(this.checkEnableUnlock);
            this.groupBox1.Controls.Add(this.checkLockPosition);
            this.groupBox1.Controls.Add(this.checkLockRotation);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posing";
            // 
            // checkUnlockHip
            // 
            this.checkUnlockHip.AutoSize = true;
            this.checkUnlockHip.Checked = true;
            this.checkUnlockHip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkUnlockHip.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUnlockHip.Location = new System.Drawing.Point(634, 19);
            this.checkUnlockHip.Name = "checkUnlockHip";
            this.checkUnlockHip.Size = new System.Drawing.Size(140, 26);
            this.checkUnlockHip.TabIndex = 3;
            this.checkUnlockHip.Text = "Unlock Hip";
            this.checkUnlockHip.UseVisualStyleBackColor = true;
            // 
            // checkEnableUnlock
            // 
            this.checkEnableUnlock.AutoSize = true;
            this.checkEnableUnlock.Checked = true;
            this.checkEnableUnlock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEnableUnlock.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEnableUnlock.Location = new System.Drawing.Point(457, 19);
            this.checkEnableUnlock.Name = "checkEnableUnlock";
            this.checkEnableUnlock.Size = new System.Drawing.Size(171, 26);
            this.checkEnableUnlock.TabIndex = 2;
            this.checkEnableUnlock.Text = "Enable unlock";
            this.checkEnableUnlock.UseVisualStyleBackColor = true;
            // 
            // checkLockPosition
            // 
            this.checkLockPosition.AutoSize = true;
            this.checkLockPosition.Checked = true;
            this.checkLockPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLockPosition.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLockPosition.Location = new System.Drawing.Point(231, 19);
            this.checkLockPosition.Name = "checkLockPosition";
            this.checkLockPosition.Size = new System.Drawing.Size(220, 26);
            this.checkLockPosition.TabIndex = 1;
            this.checkLockPosition.Text = "Lock HMD position";
            this.checkLockPosition.UseVisualStyleBackColor = true;
            // 
            // checkLockRotation
            // 
            this.checkLockRotation.AutoSize = true;
            this.checkLockRotation.Checked = true;
            this.checkLockRotation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLockRotation.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLockRotation.Location = new System.Drawing.Point(6, 19);
            this.checkLockRotation.Name = "checkLockRotation";
            this.checkLockRotation.Size = new System.Drawing.Size(219, 26);
            this.checkLockRotation.TabIndex = 0;
            this.checkLockRotation.Text = "Lock HMD rotation";
            this.checkLockRotation.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.logRichText);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(816, 75);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // logRichText
            // 
            this.logRichText.BackColor = System.Drawing.Color.Black;
            this.logRichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logRichText.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logRichText.ForeColor = System.Drawing.Color.White;
            this.logRichText.Location = new System.Drawing.Point(3, 3);
            this.logRichText.Name = "logRichText";
            this.logRichText.Size = new System.Drawing.Size(810, 69);
            this.logRichText.TabIndex = 0;
            this.logRichText.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 101);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(840, 140);
            this.Name = "Main";
            this.Text = "Playspace Mover";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox logRichText;
        private System.Windows.Forms.Button buttonTPose;
        private System.Windows.Forms.Button buttonFloat;
        private System.Windows.Forms.Button buttonSit3;
        private System.Windows.Forms.Button buttonSit2;
        private System.Windows.Forms.Button buttonSit1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonSitDangle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkEnableUnlock;
        private System.Windows.Forms.CheckBox checkLockPosition;
        private System.Windows.Forms.CheckBox checkLockRotation;
        private System.Windows.Forms.CheckBox checkUnlockHip;
    }
}

