namespace Technical.Settings.Contracts
{
    public interface ISettingValue<T> : ISetting
    {
        T Value { get; set; }
        T DefaultValue { get; set; }
    }
}