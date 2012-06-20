namespace serverBaru
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
            this.usrBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.usrTombol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrBox
            // 
            this.usrBox.Location = new System.Drawing.Point(109, 97);
            this.usrBox.Name = "usrBox";
            this.usrBox.Size = new System.Drawing.Size(100, 20);
            this.usrBox.TabIndex = 0;
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(109, 148);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(100, 20);
            this.passBox.TabIndex = 1;
            // 
            // usrTombol
            // 
            this.usrTombol.Location = new System.Drawing.Point(134, 193);
            this.usrTombol.Name = "usrTombol";
            this.usrTombol.Size = new System.Drawing.Size(75, 23);
            this.usrTombol.TabIndex = 2;
            this.usrTombol.Text = "OK!!";
            this.usrTombol.UseVisualStyleBackColor = true;
            this.usrTombol.Click += new System.EventHandler(this.usrTombol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.usrTombol);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.usrBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usrBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Button usrTombol;
    }
}

