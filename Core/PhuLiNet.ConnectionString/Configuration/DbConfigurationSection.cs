using System.Configuration;

namespace Manor.ConnectionStrings.Configuration
{
    /// <summary>
    /// A configuration section for setting the DB configuration.
    /// To enable the section, use the following code:
    /// <code>
    ///     <section name=“dbconfig“ type=“Manor.ConnectionStrings.Configuration.DbConfigurationSection, Manor.ConnectionStrings“ />
    /// </code>
    /// The configuration looks like this:
    /// <code>
    ///     
    /// <dbconfig>
    ///    <connectionStrings>
    ///         <!--WWS-->
    ///         <connection id="pkopie" crypted="false" connectionString="Data Source=pkopie;User Id=my_user;Proxy User Id=PROXY_WWS;Proxy Password=a2quilibris;Connection Timeout=720;Enlist=true;Pooling=true;Min Pool Size=1;Max Pool Size=10;Incr Pool Size=1;Decr Pool Size=1;"/>
    ///         <connection id="produ" crypted="true" connectionString="OCwwPJTdPF0xefX73FhW2IO918l+bUrQZaYD0nLO2tkOgBXy2c3/b89tSWvcc0S1x6VbqrNNycS5kfXUmgktNwgp1bpM/9i+e7vPuthUG5PSbDEy9RuArqnh6LNnJowcstyizNMr/9w33WIS/DMQgAKeLfYBshVjCnhsUSnT/ms0+42PmCnP+jsGyUoi1Ial2lK679HC4gDqsgZNEy+E3TRwCPyLUjPSsKMX73clphq5Zm9sgkYzYlZOTV3u9x3uyJ4ZeIRL6Q+ncoDHjw10tdAvVqw/rLUxm/6kZHMqBtjqPQMp8WzHL7pYnzgG3YOV/sHsTLRIPTx5jZkKGBjedEX5kbgFjiJKvns9nnBq2yX6STOlsF0uq5xkUU/BnFoac3I9cqbm1E9acLeibn1W7drFJZrFzHHVxoeXE6+RG2069jHEvUH8qSkTpUyK5He/xhZL1cbMaROONiMs3w+EiG6AgBCat6J6cHUOloDs0OoEuO+yk1rTTLqKFTTJGVSczg1Buk+3IdGHmHyDQR3cU0vsI7ymiBjtXBqSIQ+BbQ4cIYIaYhQYEA=="/>
    ///     </connectionStrings>
    /// </dbconfig>
    /// 
    /// </code>
    /// </summary>
    public class DbConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("xmlns", IsRequired = false)]
        public string XmlNsAttribute
        {
            get { return (string) this["xmlns"]; }
            set { this["xmlns"] = value; }
        }

        [ConfigurationProperty("xmlns:xsi", IsRequired = false)]
        public string XmlNsXsiAttribute
        {
            get { return (string) this["xmlns:xsi"]; }
            set { this["xmlns:xsi"] = value; }
        }

        [ConfigurationProperty("xsi:noNamespaceSchemaLocation", IsRequired = false)]
        public string SchemaLocationAttribute
        {
            get { return (string) this["xsi:noNamespaceSchemaLocation"]; }
            set { this["xsi:noNamespaceSchemaLocation"] = value; }
        }

        [ConfigurationProperty("connectionStrings", IsDefaultCollection = false)]
        public ConnectionStringsElementCollection ConnectionStrings
        {
            get { return (ConnectionStringsElementCollection) base["connectionStrings"]; }
        }

        [ConfigurationProperty("databaseTypes", IsDefaultCollection = false)]
        public DatabaseTypesElementCollection DatabaseTypes
        {
            get { return (DatabaseTypesElementCollection) base["databaseTypes"]; }
        }
    }
}