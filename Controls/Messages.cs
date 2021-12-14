using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VK_Control_Panel_Bot.Additional_Forms;
using VK_Control_Panel_Bot.Extensions;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model.Attachments;

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
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
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
        private static async Task<string> Upload(string serverUrl, string file, string fileExtension)
        {
            var data = GetBytes(file);

            using var client = new HttpClient();
            var requestContent = new MultipartFormDataContent();
            var content = new ByteArrayContent(data);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            requestContent.Add(content, "file", $"file.{fileExtension}");

            var response = client.PostAsync(serverUrl, requestContent).Result;
            return Encoding.Default.GetString(await response.Content.ReadAsByteArrayAsync());
        }
        private static byte[] GetBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        private async Task<IEnumerable<MediaAttachment>> PushDocs(string id, string attachtext)
        {
            var uploadServer = _api.Docs.GetMessagesUploadServer(long.Parse(id));
            var response = await Upload(uploadServer.UploadUrl, attachtext, Path.GetExtension(attachtext));
            var title = Path.GetFileName(attachtext);
            var attachment = new List<MediaAttachment>
            {
                _api.Docs.Save(response, title, Guid.NewGuid().ToString())[0].Instance
            };
            return attachment;
        }

        private async Task<IEnumerable<MediaAttachment>> GetAttachment(string id, string attachtext)
        {
            IEnumerable<MediaAttachment> attachment;
            try
            {
                if (!Path.GetExtension(attachtext).ToLower().Equals(".gif"))
                {
                    Image.FromFile(attachtext);
                    var uploadServer = _api.Photo.GetMessagesUploadServer(long.Parse(id));
                    var response = await Upload(uploadServer.UploadUrl, attachtext, Path.GetExtension(attachtext));
                    attachment = _api.Photo.SaveMessagesPhoto(response);
                }
                else
                {
                    attachment = await PushDocs(id, attachtext);
                }
            }
            catch (OutOfMemoryException)
            {
                attachment = await PushDocs(id, attachtext);
            }
            return attachment;
        }

        private async void SendMessage_Click(object sender, EventArgs e)
        {
            bool MessageSent = false;
            Console.WriteLine("x");
            foreach (Control control in ((Button)sender).Parent.Controls)
            {
                if (control is TextBox messageBox && control.Name.StartsWith("Message"))
                {
                    string msg = string.Join("\n", messageBox.Lines);
                    foreach (Control chat in ((Button)sender).Parent.Controls)
                    {
                        ulong? captcha_sid = null;
                        string? captcha_key = null;
                        try // captcha
                        {
                            if (chat is CheckBox CheckBoxVar && chat.Name.StartsWith("Chat")) //send message to user
                            {
                                if (!CheckBoxVar.Checked)
                                {
                                    foreach (Control userid in ((Button)sender).Parent.Controls)
                                    {
                                        if (userid is TextBox && userid.Name.StartsWith("User"))
                                        {
                                            foreach (Control attach in ((Button)sender).Parent.Controls)
                                            {
                                                if (attach is TextBox && attach.Name.StartsWith("Local"))
                                                {
                                                    MessageSent = true;
                                                    if (!string.IsNullOrEmpty(attach.Text))
                                                    {
                                                        var attachment = await GetAttachment(userid.Text, attach.Text);
                                                        _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                                                        {
                                                            RandomId = new Random().Next(),
                                                            Attachments = attachment,
                                                            UserId = long.Parse(userid.Text),
                                                            Message = msg
                                                        }); ;
                                                    }
                                                    else
                                                    {
                                                        _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                                                        {
                                                            RandomId = new Random().Next(),
                                                            UserId = long.Parse(userid.Text),
                                                            Message = msg
                                                        });
                                                    }
                                                }
                                                else
                                                {
                                                    if (!MessageSent)
                                                    {
                                                        MessageSent = true;
                                                        _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                                                        {
                                                            RandomId = new Random().Next(),
                                                            UserId = long.Parse(userid.Text),
                                                            Message = msg
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else //send message to chat
                                {
                                    foreach (Control chatid in ((Button)sender).Parent.Controls)
                                    {
                                        if (chatid is TextBox && chatid.Name.StartsWith("User"))
                                        {
                                            foreach (Control attach in ((Button)sender).Parent.Controls)
                                            {
                                                if (attach is TextBox && attach.Name.StartsWith("Local"))
                                                {
                                                    if (!string.IsNullOrEmpty(attach.Text))
                                                    {
                                                        if (!MessageSent)
                                                        {
                                                            MessageSent = true;
                                                            var attachment = await GetAttachment(chatid.Text, attach.Text);
                                                            _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                                                            {
                                                                RandomId = new Random().Next(),
                                                                Attachments = attachment,
                                                                ChatId = long.Parse(chatid.Text),
                                                                Message = msg
                                                            });
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (!MessageSent)
                                                        {
                                                            MessageSent = true;
                                                            _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                                                            {
                                                                RandomId = new Random().Next(),
                                                                ChatId = long.Parse(chatid.Text),
                                                                Message = msg
                                                            });
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (!MessageSent)
                                                    {
                                                        MessageSent = true;
                                                        _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                                                        {
                                                            RandomId = new Random().Next(),
                                                            ChatId = long.Parse(chatid.Text),
                                                            Message = msg
                                                        });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (CaptchaNeededException ex)
                        {
                            captcha_sid = ex.Sid;
                            var CaptchaForm = new CaptchaForm(ex.Img);
                            MainForm.CreateChildForm(CaptchaForm, true);
                            captcha_key = CaptchaForm.CaptchaKey;
                        }
                        MainForm.UpdateOutput("Message sent");
                        if (messageBox.ReadOnly == false)
                        {
                            messageBox.Invoke((MethodInvoker)delegate
                            {
                                messageBox.Lines = null;
                            });
                        }
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in ((Button)sender).Parent.Controls)
            {
                if (control is TextBox && control.Name.StartsWith("Local")) control.Text = "";
            }
        }

        private void ChatBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in ((CheckBox)sender).Parent.Controls)
            {
                if (((CheckBox)sender).Checked)
                {
                    if (control is Label && control.Name.StartsWith("user"))
                        control.Text = "chatid:";
                }
                else
                {
                    if (control is Label && control.Name.StartsWith("user"))
                        control.Text = "userid:";
                }
                if ((control is TextBox && control.Name.StartsWith("User")))
                    control.Text = "";
                else if (control is PictureBox && control.Name.StartsWith("Avatar"))
                    ((PictureBox)control).Image = Properties.Resources.noavatar;
            }
        }

        private void UserIdTextBox_Leave(object sender, EventArgs e)
        {
            if (long.TryParse(((TextBox)sender).Text, out long id) && !((TextBox)sender).Text.Contains("-") && !((TextBox)sender).Text.Equals("0") && !((TextBox)sender).Text.StartsWith("0"))
            {
                foreach (Control control in ((TextBox)sender).Parent.Controls)
                {
                    if (control is CheckBox && control.Name.StartsWith("Chat"))
                    {
                        if (!((CheckBox)control).Checked)
                        {
                            long[] ids = new long[] { id };
                            var p = _api.Users.Get(ids, ProfileFields.Photo200).FirstOrDefault();
                            var image = Web.GetImage(p!.Photo200.ToString());
                            foreach (Control avatar in ((TextBox)sender).Parent.Controls)
                                if (avatar is PictureBox && avatar.Name.StartsWith("Avatar"))
                                    ((PictureBox)avatar).Image = image;
                        }
                        else
                        {
                            var p = _api.Messages.GetChat(id);
                            var image = Web.GetImage(p.Photo200);
                            foreach (Control avatar in ((TextBox)sender).Parent.Controls)
                                if (avatar is PictureBox && avatar.Name.StartsWith("Avatar"))
                                    ((PictureBox)avatar).Image = image;
                        }
                    }
                }
            }
            else
            {
                ((TextBox)sender).Text = "";
                MainForm.UpdateOutput("Wrong first field format");
            }
        }
        //panel1

        private void LoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                LocalPathBox.Text = openFileDialog1.FileName;
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
            }
            else
            {
                MainForm.UpdateOutput("Wrong userId or chatId format");
            }
        }
        //panel 3

        private void BackButton_Click(object sender, EventArgs e)
        {
            ((Button)sender).Parent.SendToBack();
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
        // FirstFlooder
        private bool startflood = false;
        private async void StartButton2_Click(object sender, EventArgs e)
        {
            if (long.TryParse(ChatIdTextBox2.Text, out long id) && !ChatIdTextBox2.Text.Contains("-") && !ChatIdTextBox2.Text.StartsWith("0"))
            {
                startflood = !startflood;
                StartButton2.Text = (!startflood) ? "Start" : "Stop";
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
                        ChatIdTextBox2.Invoke((MethodInvoker)delegate
                       {
                           ChatIdTextBox2.ReadOnly = startflood;
                       });
                        StartButton2.Invoke((MethodInvoker)delegate
                       {
                           StartButton2.Text = "Start";
                       });
                        MainForm.UpdateOutput("Flood control");
                    }
                });
            }
            else
            {
                MainForm.UpdateOutput("Wrong chatId format");
            }
        }

        //Third Flooder
        private void ThirdFlooder_Click(object sender, EventArgs e)
        {
            ThirdFlooderPanel.BringToFront();
        }
        private async void StartButton3_Click(object sender, EventArgs e)
        {
            if (long.TryParse(ChatIdTextBox3.Text, out long id) && !ChatIdTextBox2.Text.Contains("-") && !ChatIdTextBox2.Text.StartsWith("0"))
            {
                startflood = !startflood;
                StartButton3.Text = (!startflood) ? "Start" : "Stop";
                ChatIdTextBox3.ReadOnly = startflood;
                long[] ids = { (2000000000 + id) };
                var conversationResult = _api.Messages.GetConversationsById(ids);
                var wc = new WebClient();
                wc.DownloadFile(conversationResult.Items.FirstOrDefault()!.ChatSettings.Photo.Photo200.ToString(), "avatar1.jpg");
                await Task.Run(() =>
                {
                    while (startflood)
                    {
                        var UplServer = _api.Photo.GetChatUploadServer((ulong)id);
                        var UplFile = Encoding.ASCII.GetString(wc.UploadFile(UplServer.UploadUrl, @"avatar1.jpg"));
                        _api.Messages.SetChatPhotoAsync(UplFile);
                        if (!startflood)
                        {
                            break;
                        }

                    }
                    File.Delete(@"avatar1.jpg");
                });
            }
            else
            {
                MainForm.UpdateOutput("Wrong chatId format");
            }
        }

        //Second Flooder
        private void SecondFlooder_Click(object sender, EventArgs e)
        {
            SecondFlooderPanel.BringToFront();
        }

        private async void StartButton4_Click(object sender, EventArgs e)
        {
            if (long.TryParse(UserIdTextBox3.Text, out long id) && !UserIdTextBox3.Text.Contains("-") && !UserIdTextBox3.Text.StartsWith("0") && UserIdTextBox3.Text.Length != 0)
            {
                ulong? captcha_sid = null;
                string? captcha_key = null;
                startflood = !startflood;
                StartButton4.Text = (!startflood) ? "Start" : "Stop";
                UserIdTextBox3.ReadOnly = startflood;
                MessageTextBoxFlood.ReadOnly = startflood;
                DelayBar1.Enabled = startflood;
                await Task.Run(() =>
                {
                    try
                    {
                        while (startflood)
                        {
                            SendMessage_Click(sender, e);
                            System.Threading.Thread.Sleep((int)(DelayBar1.Value * 1000));
                            if (!startflood)
                                break;
                        }
                    }
                    catch (CaptchaNeededException ex)
                    {
                        startflood = false;
                        UserIdTextBox3.Invoke((MethodInvoker)delegate
                        {
                            UserIdTextBox3.ReadOnly = startflood;
                        });
                        MessageTextBoxFlood.Invoke((MethodInvoker)delegate
                        {
                            MessageTextBoxFlood.ReadOnly = startflood;
                        });
                        DelayBar1.Invoke((MethodInvoker)delegate
                        {
                            DelayBar1.Enabled = startflood;
                        });
                        StartButton4.Invoke((MethodInvoker)delegate
                        {
                            StartButton4.Text = "Start";
                        });
                        MainForm.UpdateOutput("Captcha appeared due to a small delay");
                        captcha_sid = ex.Sid;
                        var CaptchaForm = new CaptchaForm(ex.Img);
                        MainForm.CreateChildForm(CaptchaForm, true);
                        captcha_key = CaptchaForm.CaptchaKey;
                    }
                });
            }
            else
            {
                MainForm.UpdateOutput("Wrong chatId format");
            }

        }
        // panel 4


        private void ScheduledMessageSend_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Equals("Send"))
            {
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync(new Tuple<object,EventArgs>(sender,e));
                ((Button)sender).Text = "Stop";
            }
            else
            {
                if (backgroundWorker1.WorkerSupportsCancellation) backgroundWorker1.CancelAsync();
                ((Button)sender).Text = "Send";
            }
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker? worker = sender as BackgroundWorker;
            Tuple<object,EventArgs>? args = e.Argument as Tuple<object,EventArgs>; 
            while (!string.Format("{0}:{1}", DateTime.Now.Hour.ToString("00"), DateTime.Now.Minute.ToString("00")).Equals(TimePickerBox.Text))
            {
                if (worker!.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                Thread.Sleep(300);
            }
            SendMessage_Click(args!.Item1,args.Item2);
            Invoke(new Action(() =>
            {
                ((Button)args!.Item1).Text = "Send";
            }));
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MainForm.UpdateOutput("Message canceled");
            }
            else if (e.Error != null)
            {
                MainForm.UpdateOutput("Error: " + e.Error.Message);
            }
            else
            {
                MainForm.UpdateOutput("Message sent");
            }
        }

        private void ScheduledMessageButton_Click(object sender, EventArgs e)
        {
            ScheduledMessagePanel.BringToFront();
            TimePickerBox.Text = DateTime.Now.AddMinutes(1).ToString("HH:mm");
        }

        private void LoadTime_Click(object sender, EventArgs e)
        {
            TimePicker timePickerForm = new();
            timePickerForm.StartPosition = FormStartPosition.CenterParent;
            timePickerForm.ShowDialog(this);
            TimePickerBox.Text = (timePickerForm.DialogResult == DialogResult.Cancel) ? TimePickerBox.Text : timePickerForm.Time;
        }
    }
}
