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
            this.buttonLie = new System.Windows.Forms.Button();
            this.buttonSit3 = new System.Windows.Forms.Button();
            this.buttonSit2 = new System.Windows.Forms.Button();
            this.buttonSit1 = new System.Windows.Forms.Button();
            this.buttonTPose = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.logRichText = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tabControl.Size = new System.Drawing.Size(764, 493);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(756, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Poses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonLie, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSit3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSit2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSit1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTPose, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 461F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(750, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonLie
            // 
            this.buttonLie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLie.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLie.Location = new System.Drawing.Point(603, 3);
            this.buttonLie.Name = "buttonLie";
            this.buttonLie.Size = new System.Drawing.Size(144, 455);
            this.buttonLie.TabIndex = 4;
            this.buttonLie.Text = "Lie";
            this.buttonLie.UseVisualStyleBackColor = true;
            this.buttonLie.Click += new System.EventHandler(this.buttonLie_Click);
            // 
            // buttonSit3
            // 
            this.buttonSit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSit3.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSit3.Location = new System.Drawing.Point(453, 3);
            this.buttonSit3.Name = "buttonSit3";
            this.buttonSit3.Size = new System.Drawing.Size(144, 455);
            this.buttonSit3.TabIndex = 3;
            this.buttonSit3.Text = "Sit 3";
            this.buttonSit3.UseVisualStyleBackColor = true;
            this.buttonSit3.Click += new System.EventHandler(this.buttonSit3_Click);
            // 
            // buttonSit2
            // 
            this.buttonSit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSit2.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSit2.Location = new System.Drawing.Point(303, 3);
            this.buttonSit2.Name = "buttonSit2";
            this.buttonSit2.Size = new System.Drawing.Size(144, 455);
            this.buttonSit2.TabIndex = 2;
            this.buttonSit2.Text = "Sit 2";
            this.buttonSit2.UseVisualStyleBackColor = true;
            this.buttonSit2.Click += new System.EventHandler(this.buttonSit2_Click);
            // 
            // buttonSit1
            // 
            this.buttonSit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSit1.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSit1.Location = new System.Drawing.Point(153, 3);
            this.buttonSit1.Name = "buttonSit1";
            this.buttonSit1.Size = new System.Drawing.Size(144, 455);
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
            this.buttonTPose.Size = new System.Drawing.Size(144, 455);
            this.buttonTPose.TabIndex = 0;
            this.buttonTPose.Text = "T-Pose";
            this.buttonTPose.UseVisualStyleBackColor = true;
            this.buttonTPose.Click += new System.EventHandler(this.buttonTPose_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(756, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.logRichText);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(756, 467);
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
            this.logRichText.Size = new System.Drawing.Size(750, 461);
            this.logRichText.TabIndex = 0;
            this.logRichText.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 493);
            this.Controls.Add(this.tabControl);
            this.Name = "Main";
            this.Text = "Playspace Mover";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonLie;
        private System.Windows.Forms.Button buttonSit3;
        private System.Windows.Forms.Button buttonSit2;
        private System.Windows.Forms.Button buttonSit1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

