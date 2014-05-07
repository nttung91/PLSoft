using System;
using DbModel.Core;

namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Object factory for CSLA "pseudo" root objects.
    /// "Pseudo" means the root object has no database entity representation (e.g. edit of single list with no parent)
    /// </summary>
    /// <typeparam name="TB"></typeparam>
    public abstract class PseudoRootObjectFactoryBase<TB> : Csla.Server.ObjectFactory, IObjectFactoryFetch,
        IObjectFactoryCreation
        where TB : IPhuLiBusinessBase
    {
        protected readonly TB BusinessObject;
        protected IUnitOfWork TheUnitOfWork;

        protected PseudoRootObjectFactoryBase(IUnitOfWork unitOfWork, TB businessObject)
        {
            TheUnitOfWork = unitOfWork;
            BusinessObject = businessObject;
        }

        public abstract void Fetch();

        public virtual void CreateNew()
        {
            throw new NotImplementedException();
        }
    }
}