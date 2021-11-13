namespace VK_Bot_CRUNGE_BOT
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
            this.TargetsTable = new System.Windows.Forms.DataGridView();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.About = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.Button();
            this.Delay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TargetsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).BeginInit();
            this.SuspendLayout();
            // 
            // TargetsTable
            // 
            this.TargetsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargetsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Link,
            this.About});
            this.TargetsTable.Location = new System.Drawing.Point(12, 12);
            this.TargetsTable.Name = "TargetsTable";
            this.TargetsTable.RowHeadersVisible = false;
            this.TargetsTable.RowTemplate.Height = 25;
            this.TargetsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TargetsTable.Size = new System.Drawing.Size(597, 300);
            this.TargetsTable.StandardTab = true;
            this.TargetsTable.TabIndex = 0;
            this.TargetsTable.VirtualMode = true;
            // 
            // Link
            // 
            this.Link.HeaderText = "Target";
            this.Link.Name = "Link";
            this.Link.Width = 298;
            // 
            // About
            // 
            this.About.HeaderText = "About";
            this.About.Name = "About";
            this.About.Width = 298;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(12, 318);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(597, 32);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // Delay
            // 
            this.Delay.Location = new System.Drawing.Point(12, 356);
            this.Delay.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.Delay.Minimum = new decimal(new int[] {
            333,
            0,
            0,
            0});
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(597, 23);
            this.Delay.TabIndex = 2;
            this.Delay.Value = new decimal(new int[] {
            333,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 388);
            this.Controls.Add(this.Delay);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.TargetsTable);
            this.Name = "MainForm";
            this.Text = "CRUNGE_BOT";
            ((System.ComponentModel.ISupportInitialize)(this.TargetsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TargetsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn About;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.NumericUpDown Delay;
    }
}
