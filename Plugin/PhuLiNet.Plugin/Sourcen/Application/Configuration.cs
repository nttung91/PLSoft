using System.Collections.Generic;
using System.Diagnostics;

namespace PhuLiNet.Plugin.Application
{
    internal class Configuration
    {
        private const string TypeMain = "main";
        private const string TypeToolbar = "toolbar";

        public string Id { get; set; }
        public bool Default { get; set; }

        public List<IMenuConfig> MenuConfigs { get; private set; }

        public IMenuConfig GetMainMenuConfig()
        {
            IMenuConfig main = GetMenuConfig(TypeMain);
            Debug.Assert(main != null, string.Format("Menu config {0} not found", TypeMain));

            return main;
        }

        public IMenuConfig GetToolbarConfig()
        {
            return GetMenuConfig(TypeToolbar);
        }

        public bool ToolbarConfigExists()
        {
            return (GetToolbarConfig() != null);
        }

        private IMenuConfig GetMenuConfig(string type)
        {
            IMenuConfig found = null;

            foreach (IMenuConfig menuConfig in MenuConfigs)
            {
                if (menuConfig.Type == type)
                {
                    found = menuConfig;
                    break;
                }
            }

            return found;
        }

        internal Configuration()
        {
            Default = false;
            MenuConfigs = new List<IMenuConfig>();
        }
    }
}