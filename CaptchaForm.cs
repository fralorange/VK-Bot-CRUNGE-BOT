using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot
{
    public partial class CaptchaForm : Form
    {
        public static Uri? url;
        public CaptchaForm(Uri IMG)
        {
            InitializeComponent();
            url = IMG;
            var client = new WebClient();
            var image = Image.FromStream(new MemoryStream(client.DownloadData(url)));
            CaptchaPictureBox.Image = image;
        }

        public string CaptchaKey { get { return CaptchaTextBox.Text; } }

        private void CaptchaConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
