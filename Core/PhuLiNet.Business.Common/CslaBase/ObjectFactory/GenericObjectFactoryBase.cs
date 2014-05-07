using System;
using DbModel.Core;
using Technical.Utilities.Exceptions;

namespace PhuLiNet.Business.Common.CslaBase.ObjectFactory
{
    /// <summary>
    /// Object factory for CSLA root objects with unique artifical key
    /// </summary>
    /// <typeparam name="TB"></typeparam>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TK"></typeparam>
    public abstract class GenericObjectFactoryBase<TB, TE, TK> : RootObjectFactoryBase, IGenericObjectFactory<TE, TK>
        where TB : IPhuLiBusinessBase
        where TE : EntityWithTypedId<TK>
    {
        protected readonly IUniqueKeyRepository<TE, TK> Repository;
        protected readonly TB BusinessObject;
        protected TE DatabaseEntity;

        protected GenericObjectFactoryBase(IUnitOfWork unitOfWork, IUniqueKeyRepository<TE, TK> repository,
            TB businessObject)
            : base(unitOfWork)
        {
            Repository = repository;            
            BusinessObject = businessObject;            
        }

        public virtual TK Id
        {
            get { throw new NotImplementedException(); }
        }

        public virtual void Get(TK id)
        {
            EnsureRepositoryIsNotNull();
            DatabaseEntity = Repository.GetById(id);
            EnsureGetLoadedEntity(id);
        }

        protected virtual void EnsureGetLoadedEntity(TK id)
        {
            if (DatabaseEntity == null)
            {
                throw new EntityNotFoundException(string.Format("Entity with id [{0}] does not exist in database", id));
            }
        }

        public virtual void Delete(TK id)
        {
            DatabaseEntity = Repository.GetById(id);
            Repository.Delete(DatabaseEntity);
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
                EnsureRepositoryIsNotNull();
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

        private void EnsureRepositoryIsNotNull()
        {
            if (Repository == null)
            {
                throw new PhuLiException("Repository is null");
            }
        }

        public override void Update()
        {
            try
            {
                EnsureRepositoryIsNotNull();
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
    }
}