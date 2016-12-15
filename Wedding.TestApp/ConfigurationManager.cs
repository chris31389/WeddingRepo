using Microsoft.Azure;
using Wedding.Common;

namespace Wedding.TestApp
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string GetSetting(string settingName)
        {
            string setting = CloudConfigurationManager.GetSetting(settingName);
            return setting;
        }
    }
}
