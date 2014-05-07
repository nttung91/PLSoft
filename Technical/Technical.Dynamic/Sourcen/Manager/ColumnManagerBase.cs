using System;
using System.Collections.Generic;
using Techical.Dynamic.Property;

namespace Techical.Dynamic.Manager
{
    public abstract class ColumnManagerBase : IColumnManagerBase
    {
        protected DynamicPropertyList Header;

        public IList<IHasDynamicProperties> ListOfObjectsWithDynamicProperties { get; set; }
        public SimpleProperty<string> Identifier { get; protected set; }

        protected ColumnManagerBase(SimpleProperty<string> identifier)
        {
            if (string.IsNullOrEmpty(identifier.Key)) throw new ArgumentException("Key of identifier is empty");
            Identifier = identifier;
        }

        protected ColumnManagerBase(SimpleProperty<string> identifier,
            IList<IHasDynamicProperties> listOfObjectsWithDynamicProperties)
        {
            Identifier = identifier;
            ListOfObjectsWithDynamicProperties = listOfObjectsWithDynamicProperties;
        }

        public abstract IDynamicPropertyList GetHeader();

        /// <summary>
        /// Creates data in DynamicProperties with given DynamicListId
        /// </summary>
        public abstract void CreateData();

        public void ClearHeader()
        {
            Header = null;
        }

        public void ClearData()
        {
            foreach (var objectWithDynamicProperty in ListOfObjectsWithDynamicProperties)
            {
                objectWithDynamicProperty.DynamicProperties.Remove(Identifier.Key);
            }
        }

        public void ClearComplete()
        {
            ClearHeader();
            ClearData();
        }

        public bool DataOk { get; protected set; }

        public bool IsColumnKey(string key)
        {
            var isKey = false;

            if (Header != null)
                isKey = Header.HasProperty(key);

            return isKey;
        }
    }
}