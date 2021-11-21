namespace VK_Control_Panel_Bot
{
    partial class CaptchaForm
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
            this.CaptchaLabel = new System.Windows.Forms.Label();
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.CaptchaConfirm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptchaLabel
            // 
            this.CaptchaLabel.AutoSize = true;
            this.CaptchaLabel.BackColor = System.Drawing.Color.Transparent;
            this.CaptchaLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptchaLabel.Font = new System.Drawing.Font("Letter Gothic Std", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CaptchaLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CaptchaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CaptchaLabel.Location = new System.Drawing.Point(94, 9);
            this.CaptchaLabel.Name = "CaptchaLabel";
            this.CaptchaLabel.Size = new System.Drawing.Size(230, 61);
            this.CaptchaLabel.TabIndex = 20;
            this.CaptchaLabel.Text = "Captcha";
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.Location = new System.Drawing.Point(26, 95);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(366, 144);
            this.CaptchaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CaptchaPictureBox.TabIndex = 21;
            this.CaptchaPictureBox.TabStop = false;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Location = new System.Drawing.Point(63, 277);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(276, 23);
            this.CaptchaTextBox.TabIndex = 22;
            // 
            // CaptchaConfirm
            // 
            this.CaptchaConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptchaConfirm.Font = new System.Drawing.Font("Letter Gothic Std", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CaptchaConfirm.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CaptchaConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CaptchaConfirm.Location = new System.Drawing.Point(53, 320);
            this.CaptchaConfirm.Name = "CaptchaConfirm";
            this.CaptchaConfirm.Size = new System.Drawing.Size(300, 50);
            this.CaptchaConfirm.TabIndex = 23;
            this.CaptchaConfirm.Text = "Confirm";
            this.CaptchaConfirm.UseVisualStyleBackColor = true;
            this.CaptchaConfirm.Click += new System.EventHandler(this.CaptchaConfirm_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 2);
            this.panel3.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(0, 380);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 2);
            this.panel1.TabIndex = 25;
            // 
            // CaptchaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 382);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.CaptchaConfirm);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.CaptchaPictureBox);
            this.Controls.Add(this.CaptchaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptchaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaptchaForm";
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CaptchaLabel;
        private System.Windows.Forms.PictureBox CaptchaPictureBox;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.Button CaptchaConfirm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}