using System;
using System.Diagnostics;
using Techical.Dynamic.Properties;
using Techical.Dynamic.Property.Filtering;
using Techical.Dynamic.Property.Grouping;
using Techical.Dynamic.Property.Sorting;

namespace Techical.Dynamic.Property
{
    /// <summary>
    /// Single dynamic property.
    /// </summary>
    [Serializable]
    public class SimpleProperty<T> : IDynamicProperty
    {
        private T _value;
        private readonly T _valueInitial;
        private string _key;
        private string _displayName;
        private string _description;
        private bool _readOnly = true;
        private bool _visible = true;
        private object _sortCriteria;
        private IGroupCriteria _groupCriteria;

        private ESortDirection _sortOrder = ESortDirection.None;

        // constructors...
        public SimpleProperty()
        {
        }

        public SimpleProperty(T value)
        {
            _value = value;
            _valueInitial = value;
        }

        public SimpleProperty(T value, string key, string displayName)
        {
            _value = value;
            _key = key;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = true;
            _visible = true;
        }

        public SimpleProperty(T value, string key, string displayName, string description)
        {
            _value = value;
            _key = key;
            _valueInitial = value;
            _displayName = displayName;
            _description = description;
            _readOnly = true;
            _visible = true;
        }

        public SimpleProperty(T value, bool readOnly)
        {
            _value = value;
            _valueInitial = value;
            _readOnly = readOnly;
            _visible = true;
        }

        public SimpleProperty(T value, string displayName)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = true;
            _visible = true;
        }

        public SimpleProperty(T value, string displayName, bool readOnly, bool visible)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
        }

        public SimpleProperty(T value, string displayName, bool readOnly, bool visible, object sortCriteria)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _sortCriteria = sortCriteria;
        }

        public SimpleProperty(T value, string displayName, string description, bool readOnly, bool visible)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _description = description;
        }

        public SimpleProperty(T value, string displayName, string description, bool readOnly, bool visible,
            object sortCriteria)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _description = description;
            _sortCriteria = sortCriteria;
        }

        public SimpleProperty(T value, string displayName, string description, bool readOnly, bool visible,
            object sortCriteria, IGroupCriteria groupCriteria)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _description = description;
            _sortCriteria = sortCriteria;
            _groupCriteria = groupCriteria;
        }

        public SimpleProperty(T value, string displayName, string description, bool readOnly, bool visible,
            ESortDirection sortOrder)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _description = description;
            _sortOrder = sortOrder;
        }

        public SimpleProperty(T value, string displayName, string description, bool readOnly, bool visible,
            object sortCriteria, ESortDirection sortOrder)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _description = description;
            _sortOrder = sortOrder;
            _sortCriteria = sortCriteria;
        }

        public SimpleProperty(T value, string displayName, string description, bool readOnly, bool visible,
            object sortCriteria, ESortDirection sortOrder, IGroupCriteria groupCriteria)
        {
            _value = value;
            _valueInitial = value;
            _displayName = displayName;
            _readOnly = readOnly;
            _visible = visible;
            _description = description;
            _sortOrder = sortOrder;
            _sortCriteria = sortCriteria;
            _groupCriteria = groupCriteria;
        }

        #region IDynamicProperty Members

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public SimpleProperty<T> SetDisplayName(string displayName)
        {
            DisplayName = displayName;
            return this;
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public ESortDirection SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public object Value
        {
            get { return _value; }
            set
            {
                if (!_readOnly)
                {
                    if (value != null)
                        _value = (T) value;
                    else
                        _value = default(T);
                }
                else
                {
                    Debug.Assert(false, "Property is readonly");
                }
            }
        }

        public string ValueAsString
        {
            get
            {
                string valueAsString = null;

                if (_value != null)
                {
                    if (_value.GetType() == typeof (bool))
                    {
                        if (Convert.ToBoolean(_value))
                            valueAsString = Resources.BooleanTrueString;
                        else
                            valueAsString = Resources.BooleanFalseString;
                    }
                    else
                        valueAsString = _value.ToString();
                }

                return valueAsString;
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }


        public object SortCriteria
        {
            get { return _sortCriteria; }
            set { _sortCriteria = value; }
        }

        public SimpleProperty<T> SetSortCriteria(object sortCriteria)
        {
            SortCriteria = sortCriteria;
            return this;
        }

        public Type GetPropertyType()
        {
            return typeof (T);
        }

        public object Clone()
        {
            T newValue = default(T);

            var cloneableValue = _value as ICloneable;

            if (cloneableValue != null)
                newValue = (T) cloneableValue.Clone();
            else
                newValue = _value;

            var _newSimpleProperty = new SimpleProperty<T>(newValue, (string) _displayName.Clone(), _readOnly, _visible);
            return _newSimpleProperty;
        }

        public override string ToString()
        {
            string toString = string.Empty;

            if (_value.GetType().IsArray)
            {
                toString = _value.ToString();
            }
            else
                toString = Convert.ToString(_value);

            return toString;
        }

        public void ResetValue()
        {
            _value = _valueInitial;
        }

        public IGroupCriteria GroupCriteria
        {
            get { return _groupCriteria; }
            set { _groupCriteria = value; }
        }

        public IFilterCriteria FilterCriteria { get; set; }

        public EAutoFilterCondition AutoFilterCondition { get; set; }

        public SimpleProperty<T> SetAutoFilterCondition(EAutoFilterCondition autoFilterCondition)
        {
            AutoFilterCondition = autoFilterCondition;
            return this;
        }

        #endregion
    }
}