using System.Configuration;

namespace Manor.ConnectionStrings.Configuration
{
    public class DatabaseConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsKey = true, IsRequired = true)]
        public string ID
        {
            get { return (string) this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("mode", IsRequired = true)]
        public string Mode
        {
            get { return (string) this["mode"]; }
            set { this["mode"] = value; }
        }
    }
}