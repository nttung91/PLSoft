using System;

namespace PhuLiNet.Business.Common.PropertyFieldListConverter
{
    [AttributeUsage(AttributeTargets.All)]
    public class PropertyDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public PropertyDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}