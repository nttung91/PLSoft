using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context
{
    /// <summary>
    /// Manages contexts and stores them in memory (RAM)
    /// </summary>
    public class MemoryContextHandler : BaseContextHandler
    {
        public MemoryContextHandler()
        {
            DataAdapter = new EmptyDataAdapter();
        }

        public override void LoadContexts()
        {
        }
    }
}