using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VK_Control_Panel_Bot
{
    public class TextAnimations
    {
        public static void Delaying(String text)
        {
            StringBuilder changedText = new("");
            foreach(char c in text)
            {
                changedText.Append(c);
                MainForm.UpdateOutput(changedText.ToString());
                Thread.Sleep(300);
            }
        }
    }
}
