using Core.DbModel.Infrastructure;
using DbModel.Core;

namespace PhuLiNet.Repository.Config
{
    public class StatelessUnitOfWork : StatelessUnitOfWorkBase
    {
        private StatelessUnitOfWork(bool createTransaction)
            : base(createTransaction, SessionProvider.GetSessionProvider())
        {
        }

        public static IStatelessUnitOfWork Create()
        {
            return Create(false);
        }

        public static IStatelessUnitOfWork Create(bool createTransaction)
        {
            return new StatelessUnitOfWork(createTransaction);
        }
    }
}
