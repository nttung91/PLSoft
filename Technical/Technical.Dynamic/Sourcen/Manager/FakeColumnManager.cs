using System.Collections.Generic;
using Techical.Dynamic.Property;
using Techical.Dynamic.Property.Filtering;

namespace Techical.Dynamic.Manager
{
    /// <summary>
    /// Generates fake columns and data for testing purposes
    /// </summary>
    public class FakeColumManager : ColumnManagerBase
    {
        public int NumberOfColumns { get; set; }

        public FakeColumManager(SimpleProperty<string> identifier) : base(identifier)
        {
            NumberOfColumns = 1;
        }

        public override IDynamicPropertyList GetHeader()
        {
            if (Header == null)
            {
                Header = new DynamicPropertyList();

                for (int i = 0; i < NumberOfColumns; i++)
                {
                    Header.AddProperty(string.Format("Column{0}", i),
                        new SimpleProperty<string>(string.Format("Column{0}", i)));
                }
            }

            return Header;
        }

        public void SetFilter(string filterString)
        {
            var headerList = GetHeader();
            foreach (var property in headerList.GetProperties(true))
            {
                property.FilterCriteria = new FilterCriteria(string.Format(filterString, property.Key));
            }
        }

        public override void CreateData()
        {
            foreach (var objectWithDynamicProperty in ListOfObjectsWithDynamicProperties)
            {
                if (objectWithDynamicProperty.DynamicProperties == null)
                    objectWithDynamicProperty.DynamicProperties = new Dictionary<string, IDynamicPropertyList>();

                var list = new DynamicPropertyList();
                var index = ListOfObjectsWithDynamicProperties.IndexOf(objectWithDynamicProperty).ToString();

                for (int i = 0; i < NumberOfColumns; i++)
                {
                    list.AddProperty(string.Format("Column-{0}", i), new SimpleProperty<string>(index + i));
                }

                objectWithDynamicProperty.DynamicProperties.Add(Identifier.Key, list);
            }
        }
    }
}