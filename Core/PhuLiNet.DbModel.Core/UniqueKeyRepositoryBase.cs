using System.Collections.Generic;

namespace DbModel.Core
{
    public abstract class UniqueKeyRepositoryBase<TE, TK> : EntityRepositoryBase<TE>, IUniqueKeyRepository<TE, TK>
        where TE : EntityWithTypedId<TK>
    {
        protected UniqueKeyRepositoryBase(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TE GetById(TK id)
        {
            return TheUnitOfWork.Session.Get<TE>(id);
        }

        public IList<TE> GetAll()
        {
            return TheUnitOfWork.Session.QueryOver<TE>().List();
        }

        public IList<TE> GetFirst(int numberOfObjects)
        {
            return TheUnitOfWork.Session.QueryOver<TE>().Take(numberOfObjects).List();
        }
    }
}