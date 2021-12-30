using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot.Additional_Forms
{
    public partial class TimePicker : Form
    {
        public TimePicker(string hours, string minutes)
        {
            InitializeComponent();
            HoursBox.Text = hours;
            MinutesBox.Text = minutes;
        }

        public string Time { get { return (HoursBox.Text + ":" + MinutesBox.Text); } }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ArrowUp1_Click(object sender, EventArgs e)
        {
            HoursBox.Text = (!HoursBox.Text.Equals("23")) ? (int.Parse(HoursBox.Text) + 1).ToString("00") : "00" ;
        }

        private void ArrowDown1_Click(object sender, EventArgs e)
        {
            HoursBox.Text = (!HoursBox.Text.Equals("00")) ? (int.Parse(HoursBox.Text) - 1).ToString("00") : "23";
        }

        private void ArrowUp2_Click(object sender, EventArgs e)
        {
            MinutesBox.Text = (!MinutesBox.Text.Equals("59")) ? (int.Parse(MinutesBox.Text) + 1).ToString("00") : "00";
        }

        private void ArrowDown2_Click(object sender, EventArgs e)
        {
            MinutesBox.Text = (!MinutesBox.Text.Equals("00")) ? (int.Parse(MinutesBox.Text) - 1).ToString("00") : "59";
        }
    }
}
