using Technical.Settings.Contracts;

namespace Windows.Core.HelpProvider.Settings
{
    internal static class HelpProviderSettings
    {
        private const string SectionId = "HelpProvider";

        private static IConfigSection Section
        {
            get
            {
                var configProvider = Technical.Settings.Provider.Get();
                var section = configProvider.LoadSection(SectionId);
                if (section == null)
                    throw new HelpProviderException(
                        "Section [{0}] does not exist. Please create this section in settings.", SectionId);
                return section;
            }
        }

        private static T GetSetting<T>(string settingName)
        {
            if (Section.ContainsSetting(settingName))
                return Section.GetSetting(settingName, default(T), false).Value;

            throw new HelpProviderException(
                "Setting '{0}' in section [{1}] does not exist. Please create this setting in settings.", settingName,
                SectionId);
        }

        public static string SharepointPath
        {
            get
            {
                var sharepointPath = GetSetting<string>("SharepointPath");
                if (sharepointPath != null && !sharepointPath.EndsWith("/"))
                    return sharepointPath + "/";
                return sharepointPath;
            }
        }
    }
}