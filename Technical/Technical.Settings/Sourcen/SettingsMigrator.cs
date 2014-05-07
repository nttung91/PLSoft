using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using Technical.Settings.Contracts;
using Technical.Utilities.Extensions;

namespace Technical.Settings
{
    /// <summary>
    /// Migrates .Net Properties-Settings classes to Technical.Settings
    /// </summary>
    public class SettingsMigrator
    {
        private string _sectionId;
        private ApplicationSettingsBase _oldSettings;

        public SettingsMigrator(ApplicationSettingsBase settings, string sectionId)
        {
            _oldSettings = settings;
            _sectionId = sectionId;
        }

        /// <summary>
        /// Creates settings in given sectionId
        /// </summary>
        public void CreateSettings()
        {
            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSection(_sectionId);
            if (section == null)
            {
                section = ((IConfigAdmin) configProvider).CreateSection(_sectionId, _sectionId);
                Debug.WriteLine(string.Format("Section [{0}] erzeugt", _sectionId), "Settings Provider");
            }

            foreach (SettingsProperty oldSetting in _oldSettings.Properties)
            {
                if (!section.ContainsSetting(oldSetting.Name))
                {
                    if (oldSetting.PropertyType == typeof (string))
                    {
                        ISettingValue<string> newSetting = ((IConfigSectionAdmin) section).AddSetting(oldSetting.Name,
                            oldSetting.DefaultValue.ToString());
                        if (!IsUserScopedSetting(oldSetting)) newSetting.Scope = ESettingScope.Application;
                    }
                    else if (oldSetting.PropertyType == typeof (bool))
                    {
                        bool defaultValue;
                        bool ok = bool.TryParse(oldSetting.DefaultValue.ToString(), out defaultValue);

                        if (ok)
                        {
                            ISettingValue<bool> newSetting = ((IConfigSectionAdmin) section).AddSetting(
                                oldSetting.Name, defaultValue);
                            if (!IsUserScopedSetting(oldSetting)) newSetting.Scope = ESettingScope.Application;
                        }
                    }
                    else if (oldSetting.PropertyType == typeof (int))
                    {
                        int defaultValue;
                        bool ok = int.TryParse(oldSetting.DefaultValue.ToString(), out defaultValue);

                        if (ok)
                        {
                            ISettingValue<int> newSetting = ((IConfigSectionAdmin) section).AddSetting(oldSetting.Name,
                                defaultValue);
                            if (!IsUserScopedSetting(oldSetting)) newSetting.Scope = ESettingScope.Application;
                        }
                    }
                    else if (oldSetting.PropertyType == typeof (decimal))
                    {
                        decimal defaultValue;
                        bool ok = decimal.TryParse(oldSetting.DefaultValue.ToString(), out defaultValue);

                        if (ok)
                        {
                            ISettingValue<decimal> newSetting =
                                ((IConfigSectionAdmin) section).AddSetting(oldSetting.Name, defaultValue);
                            if (!IsUserScopedSetting(oldSetting)) newSetting.Scope = ESettingScope.Application;
                        }
                    }
                    else if (oldSetting.PropertyType == typeof (float))
                    {
                        float defaultValue;
                        bool ok = float.TryParse(oldSetting.DefaultValue.ToString(), out defaultValue);

                        if (ok)
                        {
                            ISettingValue<float> newSetting = ((IConfigSectionAdmin) section).AddSetting(
                                oldSetting.Name, defaultValue);
                            if (!IsUserScopedSetting(oldSetting)) newSetting.Scope = ESettingScope.Application;
                        }
                    }
                    else if (oldSetting.PropertyType == typeof (Color))
                    {
                        Color defaultValue = Color.Transparent;
                        defaultValue = defaultValue.FromRgb(oldSetting.DefaultValue.ToString());

                        ISettingValue<Color> newSetting = ((IConfigSectionAdmin) section).AddSetting(oldSetting.Name,
                            defaultValue);
                        if (!IsUserScopedSetting(oldSetting)) newSetting.Scope = ESettingScope.Application;
                    }
                }
                else
                {
                    Debug.WriteLine(string.Format("Setting [{0}] existiert schon", oldSetting.Name), "Settings Provider");
                }
            }

            configProvider.SaveSection(section);
        }

        private bool IsUserScopedSetting(SettingsProperty setting)
        {
            bool userScope = false;

            foreach (DictionaryEntry attribute in setting.Attributes)
            {
                if (attribute.Value is UserScopedSettingAttribute)
                {
                    userScope = true;
                }
            }

            return userScope;
        }

        /// <summary>
        /// Migrates settings values
        /// </summary>
        public void MigrateSettingValues()
        {
            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSection(_sectionId);

            foreach (SettingsProperty oldSetting in _oldSettings.Properties)
            {
                Debug.Assert(section.ContainsSetting(oldSetting.Name),
                    string.Format("Setting {0} existiert nicht", oldSetting.Name));

                if (section.ContainsSetting(oldSetting.Name))
                {
                    if (oldSetting.PropertyType == typeof (string))
                    {
                        section.GetSetting<string>(oldSetting.Name).Value = (string) _oldSettings[oldSetting.Name];
                    }
                    else if (oldSetting.PropertyType == typeof (bool))
                    {
                        section.GetSetting<bool>(oldSetting.Name).Value = (bool) _oldSettings[oldSetting.Name];
                    }
                    else if (oldSetting.PropertyType == typeof (int))
                    {
                        section.GetSetting<int>(oldSetting.Name).Value = (int) _oldSettings[oldSetting.Name];
                    }
                    else if (oldSetting.PropertyType == typeof (decimal))
                    {
                        section.GetSetting<decimal>(oldSetting.Name).Value = (decimal) _oldSettings[oldSetting.Name];
                    }
                    else if (oldSetting.PropertyType == typeof (float))
                    {
                        section.GetSetting<float>(oldSetting.Name).Value = (float) _oldSettings[oldSetting.Name];
                    }
                    else if (oldSetting.PropertyType == typeof (Color))
                    {
                        section.GetSetting<Color>(oldSetting.Name).Value = (Color) _oldSettings[oldSetting.Name];
                    }
                }
            }

            configProvider.SaveSection(section);
        }
    }
}