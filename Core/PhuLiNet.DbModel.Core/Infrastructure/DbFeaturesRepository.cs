using System;

namespace DbModel.Core.Infrastructure
{
    public class DbFeaturesRepository : RepositoryBase
    {
        public DbFeaturesRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public DateTime GetSysDate()
        {
            return Convert.ToDateTime(TheUnitOfWork.Session.CreateSQLQuery("SELECT SYSDATE FROM DUAL").UniqueResult());
        }

        public string InstanceName()
        {
            return Convert.ToString(TheUnitOfWork.Session.CreateSQLQuery("select sys_context('USERENV','DB_NAME') as INSTANCE from dual").UniqueResult());
        }
    }
}
