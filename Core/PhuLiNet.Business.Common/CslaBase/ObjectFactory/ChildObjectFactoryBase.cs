using System;
using DbModel.Core;

namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Object factory for CSLA child objects
    /// </summary>
    public abstract class ChildObjectFactoryBase<TB, TE> : Csla.Server.ObjectFactory, IObjectFactorySynchronization,
        IObjectFactoryFetch, IObjectFactoryCreation
        where TB : IPhuLiBusinessBase
        where TE : BaseObject
    {
        protected IUnitOfWork TheUnitOfWork;
        protected TE DatabaseEntity;
        protected TB BusinessObject;

        protected ChildObjectFactoryBase(TB businessObject)
            : this(businessObject, null, null)
        {
        }

        protected ChildObjectFactoryBase(TB businessObject, TE databaseEntity)
            : this(businessObject, databaseEntity, null)
        {
        }

        protected ChildObjectFactoryBase(TB businessObject, TE databaseEntity, IUnitOfWork unitOfWork)
        {
            BusinessObject = businessObject;
            DatabaseEntity = databaseEntity;
            TheUnitOfWork = unitOfWork;
        }

        protected ChildObjectFactoryBase(IUnitOfWork unitOfWork)
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

        public virtual void CreateNew()
        {
            throw new NotImplementedException();
        }

        public abstract void Fetch();

        public abstract void InsertPreparation();

        public abstract void UpdatePreparation();
    }
}