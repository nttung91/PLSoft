using NHibernate;
using NHibernate.SqlTypes;

namespace DbModel.Core.CustomTypes
{
    public sealed class ZeroOneBoolean : AbstractGenericBoolean<string>
    {
        public ZeroOneBoolean() : base("1", "0")
        {
        }

        public override SqlType[] SqlTypes
        {
            get { return new[] {NHibernateUtil.String.SqlType}; }
        }
    }
}