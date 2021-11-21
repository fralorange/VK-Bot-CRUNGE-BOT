namespace VK_Control_Panel_Bot
{
    partial class OAuth
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
            this.OAuthEnter = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.OAuthLabel = new System.Windows.Forms.Label();
            this.OAuthTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // OAuthEnter
            // 
            this.OAuthEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OAuthEnter.Font = new System.Drawing.Font("Letter Gothic Std", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OAuthEnter.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OAuthEnter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OAuthEnter.Location = new System.Drawing.Point(63, 161);
            this.OAuthEnter.Name = "OAuthEnter";
            this.OAuthEnter.Size = new System.Drawing.Size(300, 50);
            this.OAuthEnter.TabIndex = 21;
            this.OAuthEnter.Text = "Enter";
            this.OAuthEnter.UseVisualStyleBackColor = true;
            this.OAuthEnter.Click += new System.EventHandler(this.OAuthEnter_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel6.Location = new System.Drawing.Point(63, 141);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 2);
            this.panel6.TabIndex = 20;
            // 
            // OAuthLabel
            // 
            this.OAuthLabel.AutoSize = true;
            this.OAuthLabel.BackColor = System.Drawing.Color.Transparent;
            this.OAuthLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OAuthLabel.Font = new System.Drawing.Font("Letter Gothic Std", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OAuthLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OAuthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OAuthLabel.Location = new System.Drawing.Point(127, 18);
            this.OAuthLabel.Name = "OAuthLabel";
            this.OAuthLabel.Size = new System.Drawing.Size(172, 61);
            this.OAuthLabel.TabIndex = 19;
            this.OAuthLabel.Text = "OAuth";
            // 
            // OAuthTextBox
            // 
            this.OAuthTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.OAuthTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OAuthTextBox.Font = new System.Drawing.Font("Letter Gothic Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OAuthTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OAuthTextBox.Location = new System.Drawing.Point(63, 117);
            this.OAuthTextBox.Name = "OAuthTextBox";
            this.OAuthTextBox.Size = new System.Drawing.Size(300, 23);
            this.OAuthTextBox.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 2);
            this.panel3.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(0, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 2);
            this.panel1.TabIndex = 23;
            // 
            // OAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 232);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.OAuthEnter);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.OAuthLabel);
            this.Controls.Add(this.OAuthTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OAuth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OAuthEnter;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label OAuthLabel;
        private System.Windows.Forms.TextBox OAuthTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}