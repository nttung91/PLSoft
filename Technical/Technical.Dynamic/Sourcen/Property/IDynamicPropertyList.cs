using System;
using System.Collections.Generic;
using Techical.Dynamic.Property.Sorting;

namespace Techical.Dynamic.Property
{
    /// <summary>
    /// A list of dynamic properties which allows to add/remove properties during runtime
    /// </summary>
    public interface IDynamicPropertyList
    {
        void AddProperty(string name, IDynamicProperty property);
        IDynamicProperty GetProperty(string name);
        Type GetPropertyType(string name);
        TValue GetValue<TValue>(string name);
        int IndexOf(string name);
        bool HasProperty(string name);
        void RemoveProperty(string name);
        void SetValue<TValue>(string name, TValue value);
        List<IDynamicProperty> GetProperties(bool nullValues);
        List<IDynamicProperty> GetPropertiesVisible(bool nullValues);
        List<IDynamicProperty> GetPropertiesSorted(bool nullValues, ESortBy sortBy, ESortDirection sortDirection);
        List<IDynamicProperty> GetPropertiesSorted(bool nullValues, IComparer<IDynamicProperty> comparer);
    }
}