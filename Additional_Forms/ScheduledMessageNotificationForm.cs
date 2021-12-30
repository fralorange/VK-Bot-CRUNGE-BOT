using System;
using System.Drawing;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot.Additional_Forms
{
    public partial class ScheduledMessageNotificationForm : Form
    {
        public ScheduledMessageNotificationForm()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            status = enumStatus.close;
        }

        public enum enumStatus
        {
            wait,
            start,
            close
        }

        private enumStatus status;

        private int x, y;
        public void showPopup(Image? image, string receiver)
        {
            Opacity = 0.0;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            string fName;

            for (int i = 0; i < 10; i++)
            {
                fName = "Notification_" + i.ToString();
                ScheduledMessageNotificationForm frm = (ScheduledMessageNotificationForm)Application.OpenForms[fName];

                if (frm == null)
                {
                    Name = fName;
                    x = Screen.PrimaryScreen.WorkingArea.Width - Width + 15;
                    y = Screen.PrimaryScreen.WorkingArea.Height - Height;
                    Location = new Point(x, y);
                    break;
                }
            }
            x = Screen.PrimaryScreen.WorkingArea.Width - Width - 5;

            ReceiverPic.Image = image;
            label2.Text = label2.Text.Replace("Placeholder", receiver);

            Show();
            status = enumStatus.start;
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (status)
            {
                case enumStatus.wait:
                    timer1.Interval = 5000;
                    status = enumStatus.close;
                    break;

                case enumStatus.start:
                    timer1.Interval = 1;
                    Opacity += 0.1;
                    if (x < Location.X)
                    {
                        Left--;
                    }
                    else
                    {
                        if (Opacity == 1.0)
                        {
                            status = enumStatus.wait;
                        }
                    }
                    break;

                case enumStatus.close:
                    timer1.Interval = 1;
                    Opacity -= 0.1;

                    Left -= 3;
                    if (Opacity == 0.0)
                        Close();
                    break;
            }
        }
    }
}
