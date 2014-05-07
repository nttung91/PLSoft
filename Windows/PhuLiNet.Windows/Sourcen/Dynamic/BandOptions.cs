using System;
using System.Collections.Generic;
using DevExpress.Utils;
using Techical.Dynamic.Property.Sorting;
using Techical.Dynamic.Property;

namespace Windows.Core.Dynamic
{
    public class BandOptions : ICloneable
    {
        public BandOptions()
        {
            SortBy = ESortBy.None;
            SortDirection = ESortDirection.None;
            HorzAlign = HorzAlignment.Default;
            UseTextOptions = true;
        }

        public SimpleProperty<string> BandIdentifier { get; set; }
        public IComparer<IDynamicProperty> Comparer { get; set; }
        public ESortBy SortBy { get; set; }
        public ESortDirection SortDirection { get; set; }
        public HorzAlignment HorzAlign { get; set; }
        public bool UseTextOptions { get; set; }

        public object Clone()
        {
            return new BandOptions
            {
                BandIdentifier = BandIdentifier != null ? (SimpleProperty<string>) BandIdentifier.Clone() : null,
                Comparer = Comparer,
                SortBy = SortBy,
                SortDirection = SortDirection,
                HorzAlign = HorzAlign,
                UseTextOptions = UseTextOptions
            };
        }
    }
}