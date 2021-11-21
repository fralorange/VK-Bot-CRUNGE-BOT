﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot
{
    public partial class MainForm : Form
    {
        //UI settings//
        private bool _dragging = false;
        private Point _start_point = new(0, 0);
        //
        private static MainForm? form = null;

        public MainForm()
        {
            InitializeComponent();
            form = this;
        }

        public static void UpdateOutput(string s)
        {
            if (form != null)
            {
                form.OutputLogin.Invoke((MethodInvoker)delegate
                {
                    form.OutputLogin.Text = s;
                });
            }
        }

        public static void MenuShow(bool enable)
        {
            if (form != null)
            {
                form.StripMenu.Invoke((MethodInvoker)delegate
                {
                    form.StripMenu.Visible = enable;
                });
            }
        }

        public static void CreateChildForm(Form child,bool dialog)
        {
            if (form != null)
            {
                form.Invoke((MethodInvoker)delegate
                {
                    child.StartPosition = FormStartPosition.CenterParent;
                    if (dialog)
                        child.ShowDialog(form);
                    else
                        child.Show(form);
                });
            }
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            LoginPanel.Hide();
            Thread logThread = new(() => Auth.Log(LoginBox.Text, PassBox.Text));
            logThread.Start();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Iconified_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
            WindowState = FormWindowState.Minimized;
        }

        private void UpPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new(e.X, e.Y);
        }

        private void UpPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new(p.X - _start_point.X, p.Y - _start_point.Y);
            }
        }

        private void UpPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void EyeButton_Click(object sender, EventArgs e)
        {
            PassBox.PasswordChar = (PassBox.PasswordChar == '*') ? PassBox.PasswordChar = '\0' : PassBox.PasswordChar = '*';
        }

        private void ControlsMenu_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
