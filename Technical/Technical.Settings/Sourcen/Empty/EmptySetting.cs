using System;
using Technical.Settings.Contracts;

namespace Technical.Settings.Empty
{
    internal class EmptySetting<T> : ISettingValue<T>
    {
        private string _key;
        private string _descr;
        private T _value;
        private T _defaultValue;
        private ESettingScope _scope;

        #region ISetting Members

        public string Key
        {
            get { return _key; }
        }

        public string Descr
        {
            get { return _descr; }
            set { _descr = value; }
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public object ValueAsObject
        {
            get { return _value; }
            set { _value = (T) value; }
        }

        public T DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        public object DefaultValueAsObject
        {
            get { return _defaultValue; }
        }

        public bool IsDefaultValue
        {
            get { return (_value.Equals(_defaultValue)); }
        }

        public void ResetToDefaultValue()
        {
            Value = DefaultValue;
        }

        public Type Type
        {
            get { return typeof (T); }
        }

        public ESettingScope Scope
        {
            get { return _scope; }
            set { _scope = value; }
        }

        public string SerializeValue()
        {
            throw new NotImplementedException();
        }

        public string SerializeDefaultValue()
        {
            throw new NotImplementedException();
        }

        #endregion

        public EmptySetting(string key, T value, T defaultValue)
        {
            _key = key;
            _value = value;
            _defaultValue = defaultValue;
            _scope = ESettingScope.Undefined;
        }
    }
}