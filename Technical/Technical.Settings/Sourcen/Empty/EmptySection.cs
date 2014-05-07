using System.Collections.Generic;
using Technical.Settings.Contracts;

namespace Technical.Settings.Empty
{
    /// <summary>
    /// Empty configuration section
    /// </summary>
    internal class EmptySection : IConfigSection, IConfigSectionAdmin
    {
        private readonly string _sectionId;
        private readonly Dictionary<string, ISetting> _settingList = new Dictionary<string, ISetting>();

        public EmptySection(string sectionId)
        {
            _sectionId = sectionId;
        }

        #region IConfigSection Members

        public string SectionId
        {
            get { return _sectionId; }
        }

        public bool ContainsSetting(string settingId)
        {
            return _settingList.ContainsKey(settingId);
        }

        public ISettingValue<T> GetSetting<T>(string settingId)
        {
            if (!_settingList.ContainsKey(settingId))
            {
                var setting = new EmptySetting<T>(settingId, default(T), default(T));
                _settingList.Add(settingId, setting);
            }

            return (EmptySetting<T>) _settingList[settingId];
        }

        public ISetting GetSettingUntyped(string key)
        {
            if (!_settingList.ContainsKey(key))
            {
                var setting = new EmptySetting<object>(key, default(object), default(object));
                _settingList.Add(key, setting);
            }

            return _settingList[key];
        }

        public ISettingValue<T> GetSetting<T>(string key, T defaultValue)
        {
            if (!_settingList.ContainsKey(key))
            {
                var setting = new EmptySetting<T>(key, defaultValue, defaultValue);
                _settingList.Add(key, setting);
            }

            return (EmptySetting<T>) _settingList[key];
        }

        public ISettingValue<T> GetSetting<T>(string key, T defaultValue, bool createIfMissing)
        {
            return GetSetting(key, defaultValue);
        }

        #endregion

        ISettingValue<T> IConfigSectionAdmin.AddSetting<T>(string key, T defaultValue)
        {
            var setting = new EmptySetting<T>(key, defaultValue, defaultValue);
            _settingList.Add(setting.Key, setting);
            return setting;
        }

        ISettingValue<T> IConfigSectionAdmin.AddSetting<T>(string key, T defaultValue, string description)
        {
            var setting = new EmptySetting<T>(key, defaultValue, defaultValue);
            setting.Descr = description;
            _settingList.Add(setting.Key, setting);
            return setting;
        }
    }
}