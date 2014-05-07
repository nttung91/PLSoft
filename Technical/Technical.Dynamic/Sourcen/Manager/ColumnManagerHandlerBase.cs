using System.Collections.Generic;

namespace Techical.Dynamic.Manager
{
    public abstract class ColumnManagerHandlerBase : IColumnManagerHandler
    {
        protected readonly List<IColumnManagerBase> ColumnManagers = new List<IColumnManagerBase>();

        public void Add(IColumnManagerBase columnManager)
        {
            ColumnManagers.Add(columnManager);
        }

        public virtual void CreateData()
        {
            foreach (var columnManager in ColumnManagers)
            {
                columnManager.CreateData();
            }
        }

        public void ClearData()
        {
            foreach (var columnManager in ColumnManagers)
            {
                columnManager.ClearData();
            }
        }

        public void ClearComplete()
        {
            foreach (var columnManager in ColumnManagers)
            {
                columnManager.ClearComplete();
            }
        }
    }
}