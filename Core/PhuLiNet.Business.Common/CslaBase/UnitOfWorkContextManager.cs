using System;
using System.Threading;
using Csla;
using DbModel.Core;

namespace PhuLiNet.Business.Common.CslaBase
{
    /// <summary>
    /// Provides an automated way to reuse 
    /// an Unit of work object
    /// within the context
    /// of a single data portal operation.
    /// </summary>
    public class UnitOfWorkContextManager<T> : IDisposable where T : IUnitOfWork
    {
        private static object _lock = new object();
        private readonly T _unitOfWork;
        private readonly string _label;

        public static UnitOfWorkContextManager<T> Get()
        {
            return Get("default", false);
        }

        public static UnitOfWorkContextManager<T> Get(bool createTransaction)
        {
            return Get("default", createTransaction);
        }

        private static UnitOfWorkContextManager<T> Get(string label, bool createTransaction)
        {
            lock (_lock)
            {
                var contextId = GetContextId(label);
                UnitOfWorkContextManager<T> mgr;
                if (ApplicationContext.LocalContext.Contains(contextId))
                {
                    mgr = (UnitOfWorkContextManager<T>) (ApplicationContext.LocalContext[contextId]);
                }
                else
                {
                    mgr = new UnitOfWorkContextManager<T>(label, createTransaction);
                    ApplicationContext.LocalContext[contextId] = mgr;
                }
                mgr.AddRef();
                return mgr;
            }
        }

        private UnitOfWorkContextManager(string label, bool createTransaction)
        {
            _label = label;

            var createMethod = typeof (T).GetMethod("Create", new Type[] {typeof (bool)});
            _unitOfWork = (T) createMethod.Invoke(null, new object[] {createTransaction});
        }

        private static string GetContextId(string label)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string contextId = string.Format("__unitofwork:thread-{0}|label-{1}", threadId, label);
            return contextId;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        private int _refCount;

        /// <summary>
        /// Gets the current reference count for this
        /// object.
        /// </summary>
        public int RefCount
        {
            get { return _refCount; }
        }

        private void AddRef()
        {
            _refCount += 1;
        }

        public void Complete()
        {
            lock (_lock)
            {
                if (_refCount == 1) //Value 1 means root transaction scope
                {
                    _unitOfWork.Complete();
                }
            }
        }

        private void DeRef()
        {
            lock (_lock)
            {
                _refCount -= 1;
                if (_refCount == 0)
                {
                    _unitOfWork.Dispose();
                    ApplicationContext.LocalContext.Remove(GetContextId(_label));
                }
            }
        }

        public void Dispose()
        {
            DeRef();
        }
    }
}