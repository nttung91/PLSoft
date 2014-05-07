namespace Technical.Settings.Contracts
{
    public interface ISettingInternals
    {
        void SetKey(string key);
        void SetDescr(string descr);
        void SetState(ESettingState state);
        void SetScope(ESettingScope scope);
        void SetValue(object value);
        void SetDefaultValue(object defaultValue);
        object Deserialize(string serializedObject);
    }
}