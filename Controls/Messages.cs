using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VK_Control_Panel_Bot.Extensions;
using VkNet;
using VkNet.Exception;
using VkNet.Enums.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace VK_Control_Panel_Bot.Controls
{
    public partial class Messages : Form
    {
        readonly List<Panel> borderList = new();
        readonly List<Panel> panels = new();
        readonly List<System.Windows.Forms.Button> buttons = new();
        private VkApi _api;
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

        private void UserIdTextBox2_Leave(object sender, EventArgs e)
        {
            var t = (TextBox)sender;
            if (long.TryParse(t.Text, out long id) && !t.Text.Contains("-") && !t.Text.StartsWith("0"))
            {
                long[] ids = new long[] { id };
                var p = _api.Users.Get(ids, ProfileFields.Photo200).FirstOrDefault();
                var image = Web.GetImage(p!.Photo200.ToString());
                foreach (Control pic in t.Parent.Controls)
                    if (pic is PictureBox && pic.Name.StartsWith("Avatar"))
                        ((PictureBox)pic).Image = image;
            }
            else
            {
                t.Text = "";
                MainForm.UpdateOutput("Wrong userId format");
            }
        }

        private void ChatIdTextBox_Leave(object sender, EventArgs e)
        {
            var t = (TextBox)sender;
            if (long.TryParse(t.Text, out long id) && !t.Text.Contains("-") && !t.Text.StartsWith("0"))
            {
                var p = _api.Messages.GetChat(id);
                var image = Web.GetImage(p.Photo200);
                foreach (Control pic in t.Parent.Controls)
                    if (pic is PictureBox && pic.Name.StartsWith("Chat"))
                        ((PictureBox)pic).Image = image;
            }
            else
            {
                t.Text = "";
                MainForm.UpdateOutput("Wrong chatId format");
            }
        }

        private void AnyButton_Clicked(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            string numbersOnlyButton = Regex.Replace(button.Name, @"[^\d]", string.Empty);
            panels.ForEach(delegate (Panel p)
            {
                string numbersOnlyPanel = Regex.Replace(p.Name, @"[^\d]", string.Empty);
                if (numbersOnlyButton.Equals(numbersOnlyPanel))
                {
                    p.BringToFront();
                    button.Focus();
                }
            });
        }

        //panel1

        private void UserIdTextBox_Leave(object sender, EventArgs e)
        {
            if (long.TryParse(UserIdTextBox.Text, out long id) && !UserIdTextBox.Text.Contains("-") && !UserIdTextBox.Text.Equals("0") && !UserIdTextBox.Text.StartsWith("0"))
            {
                if (!ChatBox.Checked)
                {
                    long[] ids = new long[] { id };
                    var p = _api.Users.Get(ids, ProfileFields.Photo200).FirstOrDefault();
                    var image = Web.GetImage(p!.Photo200.ToString());
                    AvatarPic1.Image = image;
                }
                else
                {
                    var p = _api.Messages.GetChat(long.Parse(UserIdTextBox.Text));
                    var image = Web.GetImage(p.Photo200);
                    AvatarPic1.Image = image;
                }
            }
            else
            {
                UserIdTextBox.Text = "";
                MainForm.UpdateOutput("Wrong first field format");
            }
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            string msg = string.Join("\n", MessageTextBox.Lines);
            if (!ChatBox.Checked)
            {
                _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                {
                    RandomId = new Random().Next(),
                    UserId = long.Parse(UserIdTextBox.Text),
                    Message = msg
                });
            }
            else
            {
                _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                {
                    RandomId = new Random().Next(),
                    ChatId = long.Parse(UserIdTextBox.Text),
                    Message = msg
                });
            }
            MainForm.UpdateOutput("Message sent");
            MessageTextBox.Lines = null;
        }

        private void ChatBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChatBox.Checked)
            {
                userId1.Text = "chatid:";
                UserIdTextBox.Text = "";
                AvatarPic1.Image = Properties.Resources.noavatar;
            }
            else
            {
                userId1.Text = "userid:";
                UserIdTextBox.Text = "";
                AvatarPic1.Image = Properties.Resources.noavatar;
            }
        }

        //panel2

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new() { UserIdTextBox2, ChatIdTextBox };
            var filteredTextBoxes = textBoxes.Where(box => !box.Text.Equals(""));
            if (filteredTextBoxes.Count() == 2)
            {
                _api.Messages.RemoveChatUser(chatId: ulong.Parse(ChatIdTextBox.Text), userId: long.Parse(UserIdTextBox2.Text));
                _api.Messages.AddChatUser(chatId: long.Parse(ChatIdTextBox.Text), userId: long.Parse(UserIdTextBox2.Text));
            } else
            {
                MainForm.UpdateOutput("Wrong userId or chatId format");
            }
        }
        //panel 3

        private void FlooderBack_Click(object sender, EventArgs e)
        {
            panel3.Focus();
            panel3.BringToFront();
        }

        private void FirstFlooderYesOption_Click(object sender, EventArgs e)
        {
            FirstFlooderPanel.BringToFront();
            FirstFlooderAttentionPanel.Visible = false;
        }

        private void FirstFlooderNoOption_Click(object sender, EventArgs e)
        {
            FirstFlooderAttentionPanel.Visible = false;
        }

        private void FirstFlooder_Click(object sender, EventArgs e)
        {
            FirstFlooderAttentionPanel.Visible = true;
        }

        private bool startflood = false;
        private async void StartButton2_Click(object sender, EventArgs e)
        {
            if (long.TryParse(ChatIdTextBox2.Text, out long id) && !ChatIdTextBox2.Text.Contains("-") && !ChatIdTextBox2.Text.StartsWith("0")) {
                startflood = !startflood;
                StartButton2.Text = (startflood) ? "Start" : "Stop";
                ChatIdTextBox2.ReadOnly = startflood;
                await Task.Run(() =>
                {
                    try
                    {
                        while (startflood)
                        {
                            _api.Messages.RemoveChatUser((ulong)id, (long)_api.UserId!);
                            _api.Messages.AddChatUser(id, (long)_api.UserId!);
                            if (!startflood)
                                break;
                        }
                    }
                    catch (TooMuchOfTheSameTypeOfActionException)
                    {
                        startflood = false;
                        ChatIdTextBox2.Invoke((MethodInvoker) delegate
                        {
                            ChatIdTextBox2.ReadOnly = startflood;
                        });
                        StartButton2.Invoke((MethodInvoker) delegate
                        {
                            StartButton2.Text = "Start";
                        });
                        MainForm.UpdateOutput("Flood control");
                    }
                });
            } else
            {
                MainForm.UpdateOutput("Wrong chatId format");
            }
        }
    }
}
