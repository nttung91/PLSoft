using System;
using DbModel.Core;

namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Base object factory for CSLA root objects
    /// </summary>
    public abstract class RootObjectFactoryBase : Csla.Server.ObjectFactory, IObjectFactoryDataStorage,
        IObjectFactorySynchronization, IObjectFactoryFetch, IObjectFactoryCreation
    {
        protected IUnitOfWork TheUnitOfWork;

        protected RootObjectFactoryBase(IUnitOfWork unitOfWork)
        {
            TheUnitOfWork = unitOfWork;
        }

        public virtual void CreateNew()
        {
            throw new NotImplementedException();
        }

        public abstract object EntityAsObject { get; set; }

        public abstract void Fetch();

        public abstract void InsertPreparation();

        public abstract void Insert();

        public abstract void UpdatePreparation();

        public abstract void Update();
    }
}