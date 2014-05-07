using System;
using NHibernate;

namespace Core.DbModel.Infrastructure
{
    public static class SessionExtensions
    {
        public static long GetSequenceNextVal(this ISession session, string sequenceName)
        {
            return
                Convert.ToInt64(session.CreateSQLQuery("SELECT " + sequenceName + ".NEXTVAL FROM DUAL").UniqueResult());
        }
    }
}