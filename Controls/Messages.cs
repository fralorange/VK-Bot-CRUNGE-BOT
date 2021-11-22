using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VK_Control_Panel_Bot.Extensions;
using VkNet;
using VkNet.Enums.Filters;

namespace VK_Control_Panel_Bot.Controls
{
    public partial class Messages : Form
    {
        readonly List<Panel> borderList = new();
        readonly List<Panel> panels = new();
        readonly List<Button> buttons = new();
        private VkApi? _api;
        public Messages(VkApi api)
        {
            _api = api;
            InitializeComponent();
        }

        private void Messages_Layout(object sender, LayoutEventArgs e)
        {
            borderList.ForEach(delegate (Panel p)
            {
                p.BringToFront();
            });
        }

        private void Messages_Load(object sender, EventArgs e)
        {
            borderList.AddMultiple(border1, border2, border3, border4, border5);
            panels.AddMultiple(panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9);
            buttons.AddMultiple(button1, button2, button3, button4, button5, button6, button7, button8, button9);
            button1.Focus();
            panel1.BringToFront();
        }

        private void UserIdTextBox_Leave(object sender, EventArgs e)
        {
            long[] ids = new long[] { long.Parse(UserIdTextBox.Text) };
            var p = _api.Users.Get(ids, ProfileFields.Photo200).FirstOrDefault();

            var request = WebRequest.Create(p.Photo200.ToString());
            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();

            AvatarPic1.Image = Image.FromStream(stream);
        }

        private void AnyButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            String numbersOnlyButton = Regex.Replace(button.Name, @"[^\d]", String.Empty);
            panels.ForEach(delegate (Panel p)
            {
                String numbersOnlyPanel = Regex.Replace(p.Name, @"[^\d]", String.Empty);
                if (numbersOnlyButton.Equals(numbersOnlyPanel))
                {
                    p.BringToFront();
                    button.Focus();
                }
            });
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            string msg = String.Join("\n", MessageTextBox.Lines);
            _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                RandomId = new Random().Next(),
                UserId = long.Parse(UserIdTextBox.Text),
                Message = msg
            });
            MessageTextBox.Lines = null;
        }
    }
}
