namespace Baru_Server
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.rTBOutputBox = new System.Windows.Forms.RichTextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // rTBOutputBox
            // 
            this.rTBOutputBox.Location = new System.Drawing.Point(12, 41);
            this.rTBOutputBox.Name = "rTBOutputBox";
            this.rTBOutputBox.ReadOnly = true;
            this.rTBOutputBox.Size = new System.Drawing.Size(260, 209);
            this.rTBOutputBox.TabIndex = 1;
            this.rTBOutputBox.TabStop = false;
            this.rTBOutputBox.Text = "";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(197, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.rTBOutputBox);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Ini Server";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox rTBOutputBox;
        public System.Windows.Forms.Button buttonStop;
    }
}

