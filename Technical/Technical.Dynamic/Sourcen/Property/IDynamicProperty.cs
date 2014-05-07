using System;
using Techical.Dynamic.Property.Filtering;
using Techical.Dynamic.Property.Grouping;
using Techical.Dynamic.Property.Sorting;

namespace Techical.Dynamic.Property
{
    /// <summary>
    /// A dynamic property. Can be added and removed during runtime <see cref="IDynamicPropertyList"/>
    /// </summary>
    public interface IDynamicProperty : ICloneable
    {
        /// <summary>
        /// Key of property
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Value of property
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// Value of property as string
        /// </summary>
        string ValueAsString { get; }

        /// <summary>
        /// Is the property visible? (in UI)
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Is the property read only?
        /// </summary>
        bool ReadOnly { get; set; }

        /// <summary>
        /// Display Name of the property (in UI)
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Description of the property
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Sort Criteria 
        /// </summary>
        object SortCriteria { get; set; }

        /// <summary>
        /// Sort order of the property (in UI)
        /// </summary>
        ESortDirection SortOrder { get; set; }

        /// <summary>
        /// Type of the property
        /// </summary>
        /// <returns></returns>
        Type GetPropertyType();

        /// <summary>
        /// Reset property to initial value
        /// </summary>
        void ResetValue();

        /// <summary>
        /// Criteria for grouping properties (eg in Bands in UI)
        /// </summary>
        IGroupCriteria GroupCriteria { get; set; }

        /// <summary>
        /// Criteria for filtering columns
        /// </summary>
        IFilterCriteria FilterCriteria { get; set; }

        /// <summary>
        /// The comparison operator types for the filter conditions created for specific columns via the automatic filtering row.
        /// </summary>
        EAutoFilterCondition AutoFilterCondition { get; set; }
    }
}