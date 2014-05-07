namespace DbModel.Core
{
    public abstract class StatelessRepositoryBase : StatelessRepositorySuperBase
    {
        protected StatelessRepositoryBase(IStatelessUnitOfWork unitOfWork)
        {
            TheUnitOfWork = unitOfWork;
        }
    }
}
