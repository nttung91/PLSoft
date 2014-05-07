using System.Configuration;
using System.Linq;

namespace Manor.ConnectionStrings.Configuration
{
    public class DatabaseConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DatabaseConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DatabaseConfigurationElement) element).ID;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "database"; }
        }

        public DatabaseConfigurationElement this[int index]
        {
            get { return (DatabaseConfigurationElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new DatabaseConfigurationElement this[string id]
        {
            get { return (DatabaseConfigurationElement) BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            object[] keys = BaseGetAllKeys();

            return keys.Any(obj => (string) obj == key);
        }
    }
}