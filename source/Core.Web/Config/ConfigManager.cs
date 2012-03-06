using System;

namespace Core.Web.Config.Implementation
{
    public class ConfigManager : IConfigManager
    {
        public Page Navigation { get; set; }

        public ConfigManager(Page navigation)
        {
            this.Navigation = navigation;
        }
    }
}
