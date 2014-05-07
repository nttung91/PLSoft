using System.Reflection;
using Technical.Reflection;
using Technical.Utilities.Extensions;
using Newtonsoft.Json;

namespace PhuLiNet.Business.Common.Context.Base
{
    public abstract class AbstractContext : IContext
    {
        public void Reset()
        {
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    PropertyReflectionHelper.SetPropertyValue(this, pi.Name, pi.GetTypeDefaultValue());
                }
            }
        }

        public virtual object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, GetType());
        }
    }
}