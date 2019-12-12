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
            this.SuspendLayout();
            // 
            // btnFileSplitter
            // 
            this.btnFileSplitter.Location = new System.Drawing.Point(152, 109);
            this.btnFileSplitter.Name = "btnFileSplitter";
            this.btnFileSplitter.Size = new System.Drawing.Size(75, 23);
            this.btnFileSplitter.TabIndex = 0;
            this.btnFileSplitter.Text = "File Splitter";
            this.btnFileSplitter.UseVisualStyleBackColor = true;
            this.btnFileSplitter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(152, 280);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 425);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnFileSplitter);
            this.Name = "Form1";
            this.Text = "txtChunk Tools Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileSplitter;
        private System.Windows.Forms.Button btnQuit;
    }
}

