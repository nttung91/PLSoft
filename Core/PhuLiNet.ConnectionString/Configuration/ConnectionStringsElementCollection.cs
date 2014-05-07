using System.Configuration;
using System.Linq;

namespace Manor.ConnectionStrings.Configuration
{
    /// <summary>
    /// Represents a collection of ConnectionStringsElement in the configuration.
    /// </summary>
    public class ConnectionStringsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringConfigurationElement) element).ID;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "connection"; }
        }

        public ConnectionStringConfigurationElement this[int index]
        {
            get { return (ConnectionStringConfigurationElement) BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public new ConnectionStringConfigurationElement this[string id]
        {
            get { return (ConnectionStringConfigurationElement) BaseGet(id); }
        }

        public bool ContainsKey(string key)
        {
            object[] keys = BaseGetAllKeys();

            return keys.Any(obj => (string) obj == key);
        }
    }
}