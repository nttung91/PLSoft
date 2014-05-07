using System;

namespace DbModel.Core
{
    public abstract class RepositoryBase : RepositorySuperBase
    {
        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentException("UnitOfWork is null");
            TheUnitOfWork = unitOfWork;
        }
    }
}