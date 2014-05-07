using System.Configuration;
using System.Linq;

namespace Manor.ConnectionStrings.Configuration
{
    public class DatabaseTypesElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DatabaseTypeConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabaseTypeConfigurationElement) element).Type;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "database-type"; }
        }

        public DatabaseTypeConfigurationElement this[int index]
        {
            get { return (DatabaseTypeConfigurationElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new DatabaseTypeConfigurationElement this[string id]
        {
            get { return (DatabaseTypeConfigurationElement) BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            object[] keys = BaseGetAllKeys();

            return keys.Any(obj => (string) obj == key);
        }
    }
}