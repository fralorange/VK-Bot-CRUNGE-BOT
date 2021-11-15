using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot
{
    public partial class OAuth : Form
    {
        public OAuth()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public string Code { get { return OAuthTextBox.Text; } }

        private void OAuthEnter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
