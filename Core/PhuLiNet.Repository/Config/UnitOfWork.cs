using Core.DbModel.Infrastructure;
using DbModel.Core;

namespace PhuLiNet.Repository.Config
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private UnitOfWork(bool createTransaction)
            : base(createTransaction, SessionProvider.GetSessionProvider())
        {
        }

        public static IUnitOfWork Create()
        {
            return Create(false);
        }

        public static IUnitOfWork Create(bool createTransaction)
        {
            return new UnitOfWork(createTransaction);
        }
    }
}
