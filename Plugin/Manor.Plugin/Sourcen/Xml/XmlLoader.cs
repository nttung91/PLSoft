using System.IO;
using System.Reflection;
using System.Xml;

namespace PhuLiNet.Plugin.Xml
{
    internal class XmlLoader
    {
        public static XmlDocument FromEmbeddedResource(Assembly assembly, string resourceName)
        {
            Stream s = assembly.GetManifestResourceStream(resourceName);
            var reader = new StreamReader(s);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(reader.ReadToEnd());
            reader.Close();
            reader.Dispose();
            s.Close();
            s.Dispose();

            return xmlDoc;
        }
    }
}