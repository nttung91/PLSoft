using System;

namespace Technical.Settings.Contracts
{
    public interface ISetting
    {
        object ValueAsObject { get; set; }
        object DefaultValueAsObject { get; }
        string Key { get; }
        string Descr { get; }
        Type Type { get; }
        ESettingScope Scope { get; set; }

        bool IsDefaultValue { get; }
        void ResetToDefaultValue();

        string SerializeValue();
        string SerializeDefaultValue();
    }
}