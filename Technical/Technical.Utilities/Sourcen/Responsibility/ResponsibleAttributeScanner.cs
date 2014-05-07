using System.Linq;
using System.Reflection;

namespace Technical.Utilities.Responsibility
{
    public class ResponsibleAttributeScanner
    {
        private readonly object _instance;

        public ResponsibleAttributeScanner(object instance)
        {
            _instance = instance;
        }

        public ResponsibleAttribute GetAttribute()
        {
            MemberInfo info = _instance.GetType();
            object[] attributes = info.GetCustomAttributes(false);
            return attributes.OfType<ResponsibleAttribute>().Select(attrib => attrib).FirstOrDefault();
        }
    }
}