namespace Technical.Settings.Contracts
{
    /// <summary>
    /// Administration interface
    /// </summary>
    public interface IConfigSectionAdmin
    {
        ISettingValue<T> AddSetting<T>(string settingId, T defaultValue);
        ISettingValue<T> AddSetting<T>(string settingId, T defaultValue, string description);
    }
}