namespace txtChunk
{
    partial class formExcelToTabDelim
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
            this.endOfLineIdent = new System.Windows.Forms.TextBox();
            this.endOfLineCheckbox = new System.Windows.Forms.CheckBox();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.btnOpenInput = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // endOfLineIdent
            // 
            this.endOfLineIdent.Location = new System.Drawing.Point(297, 54);
            this.endOfLineIdent.Name = "endOfLineIdent";
            this.endOfLineIdent.Size = new System.Drawing.Size(100, 20);
            this.endOfLineIdent.TabIndex = 26;
            this.endOfLineIdent.Text = "EOL**";
            // 
            // endOfLineCheckbox
            // 
            this.endOfLineCheckbox.AutoSize = true;
            this.endOfLineCheckbox.Location = new System.Drawing.Point(55, 57);
            this.endOfLineCheckbox.Name = "endOfLineCheckbox";
            this.endOfLineCheckbox.Size = new System.Drawing.Size(236, 17);
            this.endOfLineCheckbox.TabIndex = 25;
            this.endOfLineCheckbox.Text = "Trim rows after declared end of line identifier.";
            this.endOfLineCheckbox.UseVisualStyleBackColor = true;
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.Location = new System.Drawing.Point(230, 227);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(111, 23);
            this.btnOpenOutput.TabIndex = 24;
            this.btnOpenOutput.Text = "Open Output Folder";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // btnOpenInput
            // 
            this.btnOpenInput.Location = new System.Drawing.Point(104, 227);
            this.btnOpenInput.Name = "btnOpenInput";
            this.btnOpenInput.Size = new System.Drawing.Size(97, 23);
            this.btnOpenInput.TabIndex = 23;
            this.btnOpenInput.Text = "Open Input folder";
            this.btnOpenInput.UseVisualStyleBackColor = true;
            this.btnOpenInput.Click += new System.EventHandler(this.btnOpenInput_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(179, 270);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 22;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(179, 312);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 21;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // formExcelToTabDelim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 406);
            this.Controls.Add(this.endOfLineIdent);
            this.Controls.Add(this.endOfLineCheckbox);
            this.Controls.Add(this.btnOpenOutput);
            this.Controls.Add(this.btnOpenInput);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnQuit);
            this.Name = "formExcelToTabDelim";
            this.Text = "formExcelToTabDelim";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox endOfLineIdent;
        private System.Windows.Forms.CheckBox endOfLineCheckbox;
        private System.Windows.Forms.Button btnOpenOutput;
        private System.Windows.Forms.Button btnOpenInput;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnQuit;
    }
}