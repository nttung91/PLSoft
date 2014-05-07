using System;
using System.Reflection;
using Csla;
using DbModel.Core;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.CslaBase
{
    [Serializable]
    public abstract class PhuLiBusinessBaseVersionable<T> : PhuLiBusinessBase<T>, IVersionableBusiness
        where T : PhuLiBusinessBaseVersionable<T>
    {
        public static readonly PropertyInfo<int> VersionProperty = RegisterProperty<int>(c => c.Version);

        public int Version
        {
            get { return GetProperty(VersionProperty); }
            set
            {
                //Must be LoadProperty, business object should not change to dirty
                LoadProperty(VersionProperty, value);
            }
        }

        // ReSharper disable UnusedMember.Local
        private void ChildFlushAndEvictDeletedObjectGeneric<TK, TP>(object objectToDelete)
            // ReSharper restore UnusedMember.Local
            where TK : RepositorySuperBase
            where TP : IUnitOfWork
        {
            using (var ctx = UnitOfWorkContextManager<TP>.Get())
            {
                var repository = Activator.CreateInstance(typeof (TK), new object[] {ctx.UnitOfWork}) as TK;
                if (repository == null) return;
                repository.ForceRemoveChildObject(objectToDelete);
                ctx.Complete();
            }
        }

        protected void ChildFlushAndEvictDeletedObject(Type unitOfWork, Type repository, object objectToDelete)
        {
            typeof (PhuLiBusinessBaseVersionable<>).MakeGenericType(typeof (T))
                .GetMethod("ChildFlushAndEvictDeletedObjectGeneric", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(new[] {repository, unitOfWork})
                .Invoke(this, new[] {objectToDelete});
        }
    }
}