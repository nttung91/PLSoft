using NHibernate;
using NHibernate.SqlTypes;

namespace DbModel.Core.CustomTypes
{
    public sealed class JaNeinBoolean : AbstractGenericBoolean<string>
    {
        public JaNeinBoolean() : base("J", "N")
        {
        }

        public override SqlType[] SqlTypes
        {
            get { return new[] {NHibernateUtil.String.SqlType}; }
        }
    }
}