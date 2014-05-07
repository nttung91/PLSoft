using System;
using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using PhuLiNet.Business.Common.CslaBase;
using Techical.Dynamic.Property;
using Techical.Dynamic.Property.Sorting;

namespace PhuLiNet.Business.Common.Lookup
{
    public abstract class LookupListHandler
    {
        protected object _list;
        protected bool _listLoaded;
        protected bool _readOnly;
        protected string _valuePropertyName;
        protected Type _lookupType;
        protected IDynamicPropertyList _visibleProperties;
        protected IList<BindableBase> _filterValues;

        /// <summary>
        /// Specifies ReadOnly-Mode        
        /// </summary>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                ClearList();
            }
        }

        /// <summary>
        /// Lookup class property which represents the lookup object.
        /// </summary>
        public string ValuePropertyName
        {
            get { return _valuePropertyName; }
        }

        /// <summary>
        /// Visible properties (columns) in lookup control.
        /// </summary>
        public IDynamicPropertyList VisibleProperties
        {
            get { return _visibleProperties; }
        }

        /// <summary>
        /// Filter values which should not appear in the lookup list
        /// when we open the drop down.
        /// This will help us to prevent adding duplicate entries from the lookup list.
        /// </summary>
        public IList<BindableBase> FilterValues
        {
            get { return _filterValues; }
            set
            {
                if (_filterValues == null || !_filterValues.SequenceEqual(value))
                {
                    _filterValues = value;
                    ClearList();
                }
            }
        }

        /// <summary>
        /// Type of the lookup object
        /// </summary>
        public Type LookupType
        {
            get { return _lookupType; }
        }

        public LookupListHandler()
        {
            _listLoaded = false;
            _readOnly = false;

            _visibleProperties = new DynamicPropertyList();
            _visibleProperties.AddProperty("LookupKey",
                new SimpleProperty<object>(null, "Id", null, true, true, ESortDirection.Ascending));
            _visibleProperties.AddProperty("LookupName", new SimpleProperty<string>(null, "Beschreibung", true, true));
        }

        protected void ClearList()
        {
            _list = null;
            _listLoaded = false;
        }

        protected void ApplyFilter<T, TC>()
            where T : PhuLiLookupListBase<T, TC>
            where TC : PhuLiLookupBase<TC>
        {
            var lookupList = _list as T;
            if (lookupList == null || (lookupList.Count == 0) || FilterValues == null) return;

            foreach (var filterValue in FilterValues)
            {
                var valueTC = filterValue as TC;
                if (valueTC == null) break;
                lookupList.Remove(valueTC);
            }
        }

        public abstract object GetList();
    }
}