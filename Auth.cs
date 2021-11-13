using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet.Enums.Filters;

namespace VK_Control_Panel_Bot
{
    public class Auth
    {
        public static void Log(string login, string password)
        {
            VkApi api = new();

            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 2685278,
                Login = login,
                Password = password,
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    return Console.ReadLine();
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
