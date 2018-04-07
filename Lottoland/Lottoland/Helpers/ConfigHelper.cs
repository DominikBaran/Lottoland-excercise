using System.Configuration;

namespace Lottoland.Helpers
{
    public static class ConfigHelper
    {
        public static string GetBrowser()
        {
            return ConfigurationSettings.AppSettings["Browser"];
        }

        public static string GetTestPageUrl()
        {
            return ConfigurationSettings.AppSettings["TestPageUrl"];
        }
    }
}
