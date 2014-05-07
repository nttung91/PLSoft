using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context.Base
{
    public interface IContextHandler
    {
        void AddContext(IContext context);

        T GetContext<T>() where T : class, IContext, new();
        T GetContextCopy<T>() where T : class, IContext, new();
        bool HasContext<T>() where T : class, IContext;

        void SaveContexts();
    }
}