namespace DbModel.Core
{
    public abstract class RepositorySuperBase
    {
        protected IUnitOfWork TheUnitOfWork;

        /// <summary>
        /// Make sure, that the removal of the object is flushed to the database now and NHibernate forgets about the object.
        /// This will allow to add a new object with the same id in the same session/transaction.
        /// </summary>
        public void ForceRemoveChildObject(object o)
        {
            TheUnitOfWork.Session.Flush();
            TheUnitOfWork.Session.Evict(o);
        }
    }
}