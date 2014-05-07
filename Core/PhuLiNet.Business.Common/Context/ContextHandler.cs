using System.Diagnostics;
using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context
{
    /// <summary>
    /// Central context handler instance
    /// </summary>
    public class ContextHandler
    {
        private static IContextHandler _contextHandler;

        private ContextHandler()
        {
        }

        public static IContextHandler GetInstance()
        {
            Debug.Assert(_contextHandler != null, "ContextInstance is null. Please call CreateInstance() at startup");
            return _contextHandler;
        }

        public static void CreateInstance(IContextHandler contextHandler)
        {
            Debug.Assert(contextHandler != null, "contextHandler is null");
            Debug.Assert(_contextHandler == null, "ContextInstance exists already. Call CreateInstance only at startup.");

            _contextHandler = contextHandler;
        }

        public static void DestroyInstance()
        {
            Debug.Assert(_contextHandler != null, "ContextInstance is null");
            _contextHandler.SaveContexts();
            _contextHandler = null;
        }
    }
}