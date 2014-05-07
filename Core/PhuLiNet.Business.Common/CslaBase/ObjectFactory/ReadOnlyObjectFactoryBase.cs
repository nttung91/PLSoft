using DbModel.Core;

namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    public abstract class ReadOnlyObjectFactoryBase<TB, TE> : Csla.Server.ObjectFactory, IObjectFactoryFetch
        where TB : IPhuLiReadOnlyBase
        where TE : BaseObject
    {
        protected IUnitOfWork TheUnitOfWork;
        protected TE DatabaseEntity;
        protected readonly TB ReadOnlyBusinessObject;

        protected ReadOnlyObjectFactoryBase(TB readOnlyBusinessObject)
            : this(readOnlyBusinessObject, null, null)
        {
        }

        protected ReadOnlyObjectFactoryBase(TB readOnlyBusinessObject, TE databaseEntity)
            : this(readOnlyBusinessObject, databaseEntity, null)
        {
        }

        protected ReadOnlyObjectFactoryBase(TB readOnlyBusinessObject, TE databaseEntity, IUnitOfWork unitOfWork)
        {
            ReadOnlyBusinessObject = readOnlyBusinessObject;
            DatabaseEntity = databaseEntity;
            TheUnitOfWork = unitOfWork;
        }

        protected ReadOnlyObjectFactoryBase(IUnitOfWork unitOfWork)
        {
            TheUnitOfWork = unitOfWork;
        }

        public TE Entity
        {
            get { return DatabaseEntity; }
            set { DatabaseEntity = value; }
        }

        public object EntityAsObject
        {
            get { return DatabaseEntity; }
            set { DatabaseEntity = (TE) value; }
        }

        public abstract void Fetch();
    }
}