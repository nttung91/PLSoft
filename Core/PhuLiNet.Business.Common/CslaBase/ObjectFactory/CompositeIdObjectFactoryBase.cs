using System;
using DbModel.Core;
using Technical.Utilities.Exceptions;

namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Object factory for CSLA root objects with composite ids
    /// </summary>
    /// <typeparam name="TB"></typeparam>
    /// <typeparam name="TE"></typeparam>
    public abstract class CompositeIdObjectFactoryBase<TB, TE> : RootObjectFactoryBase
        where TB : IPhuLiBusinessBase
        where TE : EntityWithCompositeIds
    {
        protected readonly TB BusinessObject;
        protected TE DatabaseEntity;
        protected readonly IGenericRepository<TE> Repository;

        protected CompositeIdObjectFactoryBase(IUnitOfWork unitOfWork, IGenericRepository<TE> repository,
            TB businessObject)
            : base(unitOfWork)
        {
            BusinessObject = businessObject;
            Repository = repository;
        }

        public TE Entity
        {
            get { return DatabaseEntity; }
            set { DatabaseEntity = value; }
        }

        public override object EntityAsObject
        {
            get { return DatabaseEntity; }
            set { DatabaseEntity = (TE) value; }
        }

        public override void Insert()
        {
            try
            {
                Repository.Insert(DatabaseEntity);
            }
            catch (Exception exception)
            {
                if (DbExceptionUtil.IsDbConcurrencyException(exception))
                {
                    throw new ConcurrencyException("Concurrency error", exception);
                }
                throw;
            }
        }

        public override void Update()
        {
            try
            {
                Repository.Update(DatabaseEntity);
            }
            catch (Exception exception)
            {
                if (DbExceptionUtil.IsDbConcurrencyException(exception))
                {
                    throw new ConcurrencyException("Concurrency error", exception);
                }
                throw;
            }
        }

        public void Delete()
        {
            Repository.Delete(DatabaseEntity);
        }
    }
}