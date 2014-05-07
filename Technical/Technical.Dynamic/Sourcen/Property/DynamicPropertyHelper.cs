namespace Techical.Dynamic.Property
{
    //TODO add separators to parameter list
    public class DynamicPropertyHelper
    {
        public static string ConvertToString<T>(IDynamicPropertyList propertyList)
        {
            string valueString = string.Empty;

            if (propertyList != null)
            {
                foreach (IDynamicProperty p in propertyList.GetProperties(false))
                {
                    valueString += p.DisplayName.ToString() + "=" + p.Value.ToString() + "; ";
                }
            }

            return valueString;
        }
    }
}