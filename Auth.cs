using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet.Enums.Filters;
using VkNet.AudioBypassService.Extensions;
using System.Windows.Forms;

namespace VK_Control_Panel_Bot
{
    public class Auth
    {
        public static void Log(string login, string password)
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            services.AddAudioBypass();
            VkApi api = new(services);

            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 2685278,
                Login = login,
                Password = password,
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    MainForm.UpdateOutput("OAuth...");
                    return "0";
                }
            });
            if (api.IsAuthorized)
            {

            } else
            {

            }
        }
    }
}
