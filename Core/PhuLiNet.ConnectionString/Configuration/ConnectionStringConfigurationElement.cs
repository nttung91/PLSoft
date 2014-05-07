using System.Configuration;

namespace Manor.ConnectionStrings.Configuration
{
    /// <summary>
    /// represents a configuration element in the form:
    /// <code>
    ///     <connection id="pkopie" crypted="false" connectionString="Data Source=pkopie;User Id=my_user;Proxy User Id=PROXY_WWS;Proxy Password=a2quilibris;Connection Timeout=720;Enlist=true;Pooling=true;Min Pool Size=1;Max Pool Size=10;Incr Pool Size=1;Decr Pool Size=1;"/>
    /// </code>
    /// </summary>
    public class ConnectionStringConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsKey = true, IsRequired = true)]
        public string ID
        {
            get { return (string) this["id"]; }
            set { this["id"] = value; }
        }

        [ConfigurationProperty("crypted", IsRequired = true)]
        public bool Crypted
        {
            get { return (bool) this["crypted"]; }
            set { this["crypted"] = value; }
        }

        [ConfigurationProperty("connectionString", IsRequired = true)]
        public string ConnectionString
        {
            get { return (string) this["connectionString"]; }
            set { this["connectionString"] = value; }
        }
    }
}