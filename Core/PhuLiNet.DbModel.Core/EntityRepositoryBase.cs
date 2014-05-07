namespace DbModel.Core
{
    public abstract class EntityRepositoryBase<TE> : RepositoryBase, IGenericRepository<TE>
        where TE : BaseObject
    {
        protected EntityRepositoryBase(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public void Insert(TE instance)
        {
            TheUnitOfWork.Session.Save(instance);
            TheUnitOfWork.Session.Flush();
        }

        public void Update(TE instance)
        {
            TheUnitOfWork.Session.Update(instance);
            TheUnitOfWork.Session.Flush();
        }

        public void Delete(TE instance)
        {
            TheUnitOfWork.Session.Delete(instance);
            TheUnitOfWork.Session.Flush();
        }
    }
}