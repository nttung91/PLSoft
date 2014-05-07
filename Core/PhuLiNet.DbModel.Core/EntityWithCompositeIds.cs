using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DbModel.Core
{
    [Serializable]
    public abstract class EntityWithCompositeIds : BaseObject
    {
        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return
                GetType().GetProperties().Where(
                    p => Attribute.IsDefined(p, typeof (DomainSignatureAttribute), true));
        }
    }
}