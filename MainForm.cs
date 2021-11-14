using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot
{
    public partial class MainForm : Form
    {
        //UI settings//
        private bool _dragging = false;
        private Point _start_point = new(0,0);
        //
        private static MainForm form = null;

        public MainForm()
        {
            InitializeComponent();
            form = this;
        }

        public static void UpdateOutput(string s)
        {
            if (form != null)
            {
                form.OutputLogin.Invoke((MethodInvoker)delegate {
                    form.OutputLogin.Text = s;
                });
            }
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Focus();
            this.LoginPanel.Hide();
            Console.WriteLine("\n" + LoginBox.Text + "\n" + PassBox.Text);
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
            this.WindowState = FormWindowState.Minimized;
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
                Location = new(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void UpPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        
    }
}
