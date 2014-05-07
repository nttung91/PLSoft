using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PhuLiNet.Business.Common.Context.Base
{
    public abstract class BaseContextHandler : IContextHandler
    {
        protected readonly Dictionary<string, IContext> ContextList;
        protected IContextDataAdapter DataAdapter;

        protected BaseContextHandler()
        {
            ContextList = new Dictionary<string, IContext>();
        }

        public virtual void AddContext(IContext context)
        {
            ContextList.Add(context.GetType().FullName, context);
        }

        public virtual T GetContext<T>() where T : class, IContext, new()
        {
            T context;

            if (HasContext<T>())
            {
                context = (T) ContextList[typeof (T).FullName];
            }
            else
            {
                context = (T) DataAdapter.LoadContext(typeof (T)) ?? new T();
                AddContext(context);
            }

            return context;
        }

        public virtual T GetContextCopy<T>() where T : class, IContext, new()
        {
            Debug.Assert(ContextList.ContainsKey(typeof (T).FullName),
                "Context does not exist in handler. Forgot to add context type?");

            var context = GetContext<T>();
            return (T) context.Clone();
        }

        public virtual bool HasContext<T>() where T : class, IContext
        {
            return ContextList.ContainsKey(typeof (T).FullName);
        }

        public virtual void LoadContexts()
        {
            foreach (var key in ContextList.Keys.ToList())
            {
                var loadedContext = DataAdapter.LoadContext(ContextList[key].GetType());
                if (loadedContext != null) ContextList[key] = loadedContext;
            }
        }

        public virtual void SaveContexts()
        {
            foreach (KeyValuePair<string, IContext> context in ContextList)
            {
                DataAdapter.SaveContext(context.Value);
            }
        }
    }
}