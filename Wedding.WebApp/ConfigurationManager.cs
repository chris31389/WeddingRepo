using Microsoft.Extensions.Configuration;
using Wedding.Common.Core;

namespace Wedding.WebApp
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigurationManager(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string GetSetting(string settingName)
        {
            IConfigurationSection configurationSections = _configurationRoot.GetSection("AppSettings");
            string setting = configurationSections[settingName];
            return setting;
        }
    }
}