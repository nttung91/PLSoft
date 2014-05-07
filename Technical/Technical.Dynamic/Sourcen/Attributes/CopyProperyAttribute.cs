using System;

namespace Techical.Dynamic.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CopyProperyAttribute : Attribute
    {
        public bool CopyProperty = false;

        public CopyProperyAttribute(bool copyProperty)
            : base()
        {
            CopyProperty = copyProperty;
        }
    }
}