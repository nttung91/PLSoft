using System;
using System.Collections.Generic;
using System.Diagnostics;
using Techical.Dynamic.Property.Sorting;

namespace Techical.Dynamic.Property
{
    /// <summary>
    /// Dynamic property list implementation.
    /// </summary>
    [Serializable]
    public class DynamicPropertyList : IDynamicPropertyList, ICloneable
    {
        protected Dictionary<string, IDynamicProperty> _properties;

        public DynamicPropertyList()
        {
            _properties = new Dictionary<string, IDynamicProperty>();
        }

        #region IDynamicPropertyList Members

        public void AddProperty(string name, IDynamicProperty property)
        {
            Debug.Assert(!HasProperty(name), String.Format("Can't add property {0}, because it is already added.", name));

            if (HasProperty(name))
                throw new InvalidOperationException(String.Format(
                    "Can't add property {0}, because it is already added.", name));

            if (property.DisplayName == null)
                property.DisplayName = name;

            property.Key = name;

            _properties.Add(name, property);
        }

        public int IndexOf(string name)
        {
            Debug.Assert(HasProperty(name),
                String.Format("Can't get property {0} value, because it doesn't exist.", name));

            int index = -1;
            if (HasProperty(name))
            {
                index = 0;
                foreach (KeyValuePair<string, IDynamicProperty> p in _properties)
                {
                    if (p.Value.Key == name)
                    {
                        break;
                    }
                    index++;
                }
            }

            return index;
        }

        public IDynamicProperty GetProperty(string name)
        {
            Debug.Assert(HasProperty(name),
                String.Format("Can't get property {0} value, because it doesn't exist.", name));

            IDynamicProperty property = null;
            if (HasProperty(name)) property = _properties[name] as IDynamicProperty;

            return property;
        }

        public TValue GetValue<TValue>(string name)
        {
            IDynamicProperty property = GetProperty(name);

            if (property != null && property.Value != null)
                return (TValue) property.Value;

            return default(TValue);
        }

        public bool HasProperty(string name)
        {
            return _properties == null ? false : _properties.ContainsKey(name);
        }

        public void RemoveProperty(string name)
        {
            _properties.Remove(name);
        }

        public void SetValue<TValue>(string name, TValue value)
        {
            IDynamicProperty property = GetProperty(name);

            if (property != null)
                property.Value = value;
        }

        public List<IDynamicProperty> GetProperties(bool nullValues)
        {
            //copy and return property list
            var properties = new List<IDynamicProperty>();

            foreach (KeyValuePair<string, IDynamicProperty> p in _properties)
            {
                if (nullValues)
                    properties.Add(p.Value);
                else
                {
                    if (p.Value.Value != null)
                        properties.Add(p.Value);
                }
            }

            return properties;
        }

        public List<IDynamicProperty> GetPropertiesSorted(bool nullValues, ESortBy sortBy, ESortDirection sortDirection)
        {
            //copy and return property list
            var properties = new List<IDynamicProperty>();

            properties = GetProperties(nullValues);

            switch (sortBy)
            {
                case ESortBy.None:
                    break;
                case ESortBy.Key:
                    if (sortDirection == ESortDirection.Ascending)
                        properties.Sort(new PropertyKeyComparer());
                    else
                        properties.Sort(new PropertyKeyComparerDesc());
                    break;
                case ESortBy.Value:
                    if (sortDirection == ESortDirection.Ascending)
                        properties.Sort(new PropertyValueAsStringComparer());
                    else
                        properties.Sort(new PropertyValueAsStringComparerDesc());
                    break;
                case ESortBy.ValueAsString:
                    if (sortDirection == ESortDirection.Ascending)
                        properties.Sort(new PropertyValueAsStringComparer());
                    else
                        properties.Sort(new PropertyValueAsStringComparerDesc());
                    break;
                case ESortBy.DisplayName:
                    if (sortDirection == ESortDirection.Ascending)
                        properties.Sort(new PropertyDisplayNameComparer());
                    else
                        properties.Sort(new PropertyDisplayNameComparerDesc());
                    break;
                case ESortBy.Description:
                    if (sortDirection == ESortDirection.Ascending)
                        properties.Sort(new PropertyDescriptionComparer());
                    else
                        properties.Sort(new PropertyDescriptionComparerDesc());
                    break;
                case ESortBy.SortCriteria:
                    if (sortDirection == ESortDirection.Ascending)
                        properties.Sort(new PropertySortCriteriaComparer());
                    else
                        properties.Sort(new PropertySortCriteriaComparerDesc());
                    break;
                case ESortBy.Custom:
                    Debug.Assert(false,
                        "For custom sorting use GetPropertiesSorted(bool nullValues, IComparer<IDynamicProperty> comparer) function");
                    break;
                default:
                    break;
            }

            return properties;
        }

        public List<IDynamicProperty> GetPropertiesSorted(bool nullValues, IComparer<IDynamicProperty> comparer)
        {
            //copy and return property list
            var properties = new List<IDynamicProperty>();

            properties = GetProperties(nullValues);
            properties.Sort(comparer);

            return properties;
        }

        public List<IDynamicProperty> GetPropertiesVisible(bool nullValues)
        {
            //copy and return property list
            var properties = new List<IDynamicProperty>();

            foreach (KeyValuePair<string, IDynamicProperty> p in _properties)
            {
                if (nullValues)
                {
                    if (p.Value.Visible)
                        properties.Add(p.Value);
                }
                else
                {
                    if (p.Value.Visible && p.Value.Value != null)
                        properties.Add(p.Value);
                }
            }

            return properties;
        }

        public Type GetPropertyType(string name)
        {
            IDynamicProperty property = GetProperty(name);

            return property.GetPropertyType();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            var newPropertyList = new DynamicPropertyList();

            foreach (KeyValuePair<string, IDynamicProperty> p in _properties)
            {
                newPropertyList.AddProperty((string) p.Key.Clone(), (IDynamicProperty) p.Value.Clone());
            }

            return newPropertyList;
        }

        #endregion
    }
}