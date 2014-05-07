using NHibernate;
using NHibernate.SqlTypes;

namespace DbModel.Core.CustomTypes
{
    public sealed class YesNoBoolean : AbstractGenericBoolean<string>
    {
        public YesNoBoolean() : base("Y", "N")
        {
        }

        public override SqlType[] SqlTypes
        {
            get { return new[] {NHibernateUtil.String.SqlType}; }
        }
    }
}