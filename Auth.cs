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
using VkNet.Exception;

namespace VK_Control_Panel_Bot
{
    public class Auth
    {
        public static void Log(string login, string password)
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            services.AddAudioBypass();
            VkApi api = new(services);
            ulong? captcha_sid = null;
            string? captcha_key = null;
            try 
            { 
                api.Authorize(new ApiAuthParams
                {
                    ApplicationId = 2685278,
                    Login = login,
                    Password = password,
                    Settings = Settings.All,
                    TwoFactorAuthorization = () =>
                    {
                        var OAuthForm = new OAuth();
                        OAuthForm.ShowDialog();
                        return OAuthForm.Code;
                    }
                });
            } catch(CaptchaNeededException ex)
            {
                captcha_sid = ex.Sid;
                var form = new CaptchaForm(ex.Img);
                form.ShowDialog();
                captcha_key = form.CaptchaKey;
            }
            if (api.IsAuthorized)
            {
                MainForm.UpdateOutput("Welcome");
            } else
            {
                MainForm.UpdateOutput("Wrong");
            }
        }
    }
}
