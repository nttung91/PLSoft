namespace Technical.Settings.Contracts
{
    public interface IConfigSection
    {
        string SectionId { get; }

        ISettingValue<T> GetSetting<T>(string settingId);
        ISettingValue<T> GetSetting<T>(string settingId, T defaultValue);
        ISettingValue<T> GetSetting<T>(string settingId, T defaultValue, bool createIfMissing);

        ISetting GetSettingUntyped(string settingId);

        bool ContainsSetting(string settingId);
    }
}