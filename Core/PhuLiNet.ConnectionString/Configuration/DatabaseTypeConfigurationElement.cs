using System.Configuration;

namespace Manor.ConnectionStrings.Configuration
{
    public class DatabaseTypeConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("type", IsKey = true, IsRequired = true)]
        public string Type
        {
            get { return (string) this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public DatabaseConfigurationElementCollection Databases
        {
            get { return (DatabaseConfigurationElementCollection) base[""]; }
        }
    }
}