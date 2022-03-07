namespace txtChunk
{
    partial class Form1
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
            this.btnFileSplitter = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnExcelTabDelimited = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFileSplitter
            // 
            this.btnFileSplitter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFileSplitter.Location = new System.Drawing.Point(96, 95);
            this.btnFileSplitter.Name = "btnFileSplitter";
            this.btnFileSplitter.Size = new System.Drawing.Size(135, 23);
            this.btnFileSplitter.TabIndex = 0;
            this.btnFileSplitter.Text = "File Splitter";
            this.btnFileSplitter.UseVisualStyleBackColor = true;
            this.btnFileSplitter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuit.Location = new System.Drawing.Point(126, 280);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExcelTabDelimited
            // 
            this.btnExcelTabDelimited.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExcelTabDelimited.Location = new System.Drawing.Point(96, 124);
            this.btnExcelTabDelimited.Name = "btnExcelTabDelimited";
            this.btnExcelTabDelimited.Size = new System.Drawing.Size(135, 23);
            this.btnExcelTabDelimited.TabIndex = 2;
            this.btnExcelTabDelimited.Text = "Excel To Tab Delimited";
            this.btnExcelTabDelimited.Click += new System.EventHandler(this.btnExcelTabDelimited_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 390);
            this.Controls.Add(this.btnExcelTabDelimited);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnFileSplitter);
            this.Name = "Form1";
            this.Text = "txtChunk Tools Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileSplitter;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnExcelTabDelimited;
    }
}

