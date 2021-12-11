using System.Threading;
using VkNet;
using VkNet.Model;
using VkNet.Enums.Filters;
using VkNet.AudioBypassService.Extensions;
using VkNet.Exception;
using VkNet.AudioBypassService.Exceptions;
using System.IO;

namespace VK_Control_Panel_Bot
{
    public class Auth
    {
        public static VkApi? Log(string login, string password, bool SaveAccount)
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
                    ApplicationId = 8000623,
                    Login = login,
                    Password = password,
                    Settings = Settings.All,
                    TwoFactorAuthorization = () =>
                    {
                        var OAuthForm = new OAuth();
                        MainForm.CreateChildForm(OAuthForm, true);
                        return OAuthForm.Code;
                    }
                }); 
            } catch(CaptchaNeededException ex)
            {
                captcha_sid = ex.Sid;
                var CaptchaForm = new CaptchaForm(ex.Img);
                MainForm.CreateChildForm(CaptchaForm,true);
                captcha_key = CaptchaForm.CaptchaKey;
            } catch (VkAuthException)
            {
                MainForm.LoginShow(true);
                MainForm.UpdateOutput("Wrong credentials or code");
                return null;
            }

            if (api.IsAuthorized)
            {
                // make async instead new threads
                if (SaveAccount)
                {
                    File.WriteAllText("Accounts.txt", api.Token);
                }
                Thread StatusThread = new(() => TextAnimations.Delaying("Welcome!"));
                StatusThread.Start();
                MainForm.MenuShow(true);
                return api;
            } else
            {
                // same
                Thread StatusThread = new(() => TextAnimations.Delaying("Something wrong."));
                StatusThread.Start();
                return null;
            }
        }

        public static VkApi? Log(string Token)
        {
            VkApi api = new();
            ulong? captcha_sid = null;
            string? captcha_key = null;
            try
            {
                api.Authorize(new ApiAuthParams
                {
                    AccessToken = Token
                });
            }
            catch (CaptchaNeededException ex)
            {
                captcha_sid = ex.Sid;
                var CaptchaForm = new CaptchaForm(ex.Img);
                MainForm.CreateChildForm(CaptchaForm, true);
                captcha_key = CaptchaForm.CaptchaKey;
            }
            return api;
        }
    }
}
