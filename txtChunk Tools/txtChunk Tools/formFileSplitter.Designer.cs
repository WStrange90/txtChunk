namespace txtChunk
{
    partial class formFileSplitter
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
            this.components = new System.ComponentModel.Container();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lineOptionInput = new System.Windows.Forms.TextBox();
            this.txtbxOldDelim = new System.Windows.Forms.TextBox();
            this.chkbxFileSplit = new System.Windows.Forms.CheckBox();
            this.chkbxDelimiter = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxNewDelim = new System.Windows.Forms.TextBox();
            this.chkbxFileHeaders = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnOpenInput = new System.Windows.Forms.Button();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.delimiterTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(461, 160);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(111, 23);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lineOptionInput
            // 
            this.lineOptionInput.Location = new System.Drawing.Point(296, 12);
            this.lineOptionInput.Name = "lineOptionInput";
            this.lineOptionInput.Size = new System.Drawing.Size(130, 20);
            this.lineOptionInput.TabIndex = 1;
            this.lineOptionInput.Text = "5000";
            this.lineOptionInput.TextChanged += new System.EventHandler(this.lineOptionInput_TextChanged);
            this.lineOptionInput.Validating += new System.ComponentModel.CancelEventHandler(this.lineOptionInput_Validating);
            // 
            // txtbxOldDelim
            // 
            this.txtbxOldDelim.Location = new System.Drawing.Point(188, 56);
            this.txtbxOldDelim.Name = "txtbxOldDelim";
            this.txtbxOldDelim.Size = new System.Drawing.Size(24, 20);
            this.txtbxOldDelim.TabIndex = 4;
            this.txtbxOldDelim.Text = "\\t";
            this.txtbxOldDelim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkbxFileSplit
            // 
            this.chkbxFileSplit.AutoSize = true;
            this.chkbxFileSplit.Checked = true;
            this.chkbxFileSplit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxFileSplit.Location = new System.Drawing.Point(12, 16);
            this.chkbxFileSplit.Name = "chkbxFileSplit";
            this.chkbxFileSplit.Size = new System.Drawing.Size(278, 17);
            this.chkbxFileSplit.TabIndex = 6;
            this.chkbxFileSplit.Text = "Split file? Enter the number of lines to make child files:";
            this.chkbxFileSplit.UseVisualStyleBackColor = true;
            this.chkbxFileSplit.CheckedChanged += new System.EventHandler(this.chkbxFileSplit_CheckedChanged);
            // 
            // chkbxDelimiter
            // 
            this.chkbxDelimiter.AutoSize = true;
            this.chkbxDelimiter.Checked = true;
            this.chkbxDelimiter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxDelimiter.Location = new System.Drawing.Point(12, 59);
            this.chkbxDelimiter.Name = "chkbxDelimiter";
            this.chkbxDelimiter.Size = new System.Drawing.Size(118, 17);
            this.chkbxDelimiter.TabIndex = 7;
            this.chkbxDelimiter.Text = "Replace delimiters?";
            this.chkbxDelimiter.UseVisualStyleBackColor = true;
            this.chkbxDelimiter.CheckedChanged += new System.EventHandler(this.chkbxDelimiter_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Old:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "New:";
            // 
            // txtbxNewDelim
            // 
            this.txtbxNewDelim.Location = new System.Drawing.Point(265, 56);
            this.txtbxNewDelim.Name = "txtbxNewDelim";
            this.txtbxNewDelim.Size = new System.Drawing.Size(24, 20);
            this.txtbxNewDelim.TabIndex = 10;
            this.txtbxNewDelim.Text = "|";
            this.txtbxNewDelim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkbxFileHeaders
            // 
            this.chkbxFileHeaders.AutoSize = true;
            this.chkbxFileHeaders.Checked = true;
            this.chkbxFileHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxFileHeaders.Location = new System.Drawing.Point(12, 99);
            this.chkbxFileHeaders.Name = "chkbxFileHeaders";
            this.chkbxFileHeaders.Size = new System.Drawing.Size(302, 17);
            this.chkbxFileHeaders.TabIndex = 11;
            this.chkbxFileHeaders.Text = "My data files have headers that need to stay with the data.";
            this.chkbxFileHeaders.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(461, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(111, 23);
            this.btnRun.TabIndex = 12;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnOpenInput
            // 
            this.btnOpenInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenInput.Location = new System.Drawing.Point(461, 71);
            this.btnOpenInput.Name = "btnOpenInput";
            this.btnOpenInput.Size = new System.Drawing.Size(111, 23);
            this.btnOpenInput.TabIndex = 13;
            this.btnOpenInput.Text = "Open Input folder";
            this.btnOpenInput.UseVisualStyleBackColor = true;
            this.btnOpenInput.Click += new System.EventHandler(this.btnOpenInput_Click);
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenOutput.Location = new System.Drawing.Point(461, 100);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(111, 23);
            this.btnOpenOutput.TabIndex = 14;
            this.btnOpenOutput.Text = "Open Output Folder";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // delimiterTooltip
            // 
            this.delimiterTooltip.IsBalloon = true;
            this.delimiterTooltip.ShowAlways = true;
            this.delimiterTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.delimiterTooltip.ToolTipTitle = "Common unprintable delimiters:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::txtChunk.Properties.Resources.infoIcon;
            this.pictureBox1.Location = new System.Drawing.Point(126, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.delimiterTooltip.SetToolTip(this.pictureBox1, "Tab= \'\\t\', line= \'\\n\', carriage return= \'\\r\'");
            // 
            // formFileSplitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOpenOutput);
            this.Controls.Add(this.btnOpenInput);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chkbxFileHeaders);
            this.Controls.Add(this.txtbxNewDelim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkbxDelimiter);
            this.Controls.Add(this.chkbxFileSplit);
            this.Controls.Add(this.txtbxOldDelim);
            this.Controls.Add(this.lineOptionInput);
            this.Controls.Add(this.btnQuit);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "formFileSplitter";
            this.Text = "File Splitter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox lineOptionInput;
        private System.Windows.Forms.TextBox txtbxOldDelim;
        private System.Windows.Forms.CheckBox chkbxFileSplit;
        private System.Windows.Forms.CheckBox chkbxDelimiter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxNewDelim;
        private System.Windows.Forms.CheckBox chkbxFileHeaders;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnOpenInput;
        private System.Windows.Forms.Button btnOpenOutput;
        private System.Windows.Forms.ToolTip delimiterTooltip;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}