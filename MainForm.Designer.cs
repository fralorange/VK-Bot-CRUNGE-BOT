namespace VK_Control_Panel_Bot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconified = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.UpPanel = new System.Windows.Forms.Panel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.EnterButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.TwoFactPanel = new System.Windows.Forms.Panel();
            this.OAuthEnterButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.OAuthBox = new System.Windows.Forms.TextBox();
            this.UpPanel.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TwoFactPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // iconified
            // 
            resources.ApplyResources(this.iconified, "iconified");
            this.iconified.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconified.ForeColor = System.Drawing.SystemColors.Highlight;
            this.iconified.Name = "iconified";
            this.iconified.TabStop = false;
            this.iconified.UseVisualStyleBackColor = true;
            this.iconified.Click += new System.EventHandler(this.iconified_Click);
            // 
            // exit
            // 
            resources.ApplyResources(this.exit, "exit");
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.exit.Name = "exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // UpPanel
            // 
            this.UpPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.UpPanel.Controls.Add(this.iconified);
            this.UpPanel.Controls.Add(this.exit);
            resources.ApplyResources(this.UpPanel, "UpPanel");
            this.UpPanel.Name = "UpPanel";
            this.UpPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpPanel_MouseDown);
            this.UpPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UpPanel_MouseMove);
            this.UpPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpPanel_MouseUp);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.EnterButton);
            this.LoginPanel.Controls.Add(this.pictureBox3);
            this.LoginPanel.Controls.Add(this.pictureBox2);
            this.LoginPanel.Controls.Add(this.panel2);
            this.LoginPanel.Controls.Add(this.panel4);
            this.LoginPanel.Controls.Add(this.LoginLabel);
            this.LoginPanel.Controls.Add(this.pictureBox1);
            this.LoginPanel.Controls.Add(this.PassBox);
            this.LoginPanel.Controls.Add(this.LoginBox);
            this.LoginPanel.Controls.Add(this.TwoFactPanel);
            resources.ApplyResources(this.LoginPanel, "LoginPanel");
            this.LoginPanel.Name = "LoginPanel";
            // 
            // EnterButton
            // 
            resources.ApplyResources(this.EnterButton, "EnterButton");
            this.EnterButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::VK_Control_Panel_Bot.Properties.Resources.password;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::VK_Control_Panel_Bot.Properties.Resources.login1;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // LoginLabel
            // 
            resources.ApplyResources(this.LoginLabel, "LoginLabel");
            this.LoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoginLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LoginLabel.Name = "LoginLabel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VK_Control_Panel_Bot.Properties.Resources.VKLOGO;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // PassBox
            // 
            this.PassBox.BackColor = System.Drawing.SystemColors.Control;
            this.PassBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.PassBox, "PassBox");
            this.PassBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PassBox.Name = "PassBox";
            // 
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.SystemColors.Control;
            this.LoginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LoginBox, "LoginBox");
            this.LoginBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LoginBox.Name = "LoginBox";
            // 
            // TwoFactPanel
            // 
            this.TwoFactPanel.Controls.Add(this.OAuthEnterButton);
            this.TwoFactPanel.Controls.Add(this.panel1);
            this.TwoFactPanel.Controls.Add(this.label1);
            this.TwoFactPanel.Controls.Add(this.OAuthBox);
            resources.ApplyResources(this.TwoFactPanel, "TwoFactPanel");
            this.TwoFactPanel.Name = "TwoFactPanel";
            this.TwoFactPanel.TabStop = true;
            // 
            // OAuthEnterButton
            // 
            resources.ApplyResources(this.OAuthEnterButton, "OAuthEnterButton");
            this.OAuthEnterButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OAuthEnterButton.Name = "OAuthEnterButton";
            this.OAuthEnterButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Name = "label1";
            // 
            // OAuthBox
            // 
            this.OAuthBox.BackColor = System.Drawing.SystemColors.Control;
            this.OAuthBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.OAuthBox, "OAuthBox");
            this.OAuthBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.OAuthBox.Name = "OAuthBox";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.UpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.UpPanel.ResumeLayout(false);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TwoFactPanel.ResumeLayout(false);
            this.TwoFactPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button iconified;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Panel UpPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Panel TwoFactPanel;
        private System.Windows.Forms.Button OAuthEnterButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OAuthBox;
    }
}
