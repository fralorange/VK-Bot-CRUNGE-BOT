using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VK_Control_Panel_Bot.Extensions
{
    public class Web
    {
        public static Image GetImage(string url)
        {
            var request = WebRequest.Create(url);
            using var response = request.GetResponse();
            using var stream = response.GetResponseStream();

            return Image.FromStream(stream);
        }
    }
}
