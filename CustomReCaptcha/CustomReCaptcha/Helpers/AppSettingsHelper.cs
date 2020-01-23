using System.Configuration;
using CustomReCaptcha.Helpers.Interfaces;

namespace CustomReCaptcha.Helpers
{
    public class AppSettingsHelper: IAppSettingsHelper
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}