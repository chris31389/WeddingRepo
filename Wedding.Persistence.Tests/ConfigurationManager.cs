using System.Collections.Generic;
using Wedding.Common;

namespace Wedding.Persistence.Tests
{
    class ConfigurationManager : IConfigurationManager
    {
        private IDictionary<string, string> _settings;

        public ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
            _settings.Add("SqlConnectionString", );
        }

        public string GetSetting(string settingName)
        {
            string setting;
            _settings.TryGetValue(settingName, out setting);
            return setting;
        }
    }
}
