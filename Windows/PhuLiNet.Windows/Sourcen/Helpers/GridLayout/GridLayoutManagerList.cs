using System.Collections.Generic;
using System.Diagnostics;

namespace Windows.Core.Helpers.GridLayout
{
    /// <summary>
    /// Verwaltet eine Liste von Layout Managern
    /// </summary>
    public class GridLayoutManagerList : List<IGridLayoutManager>, IGridLayoutHandler
    {
        #region IGridLayoutHandler Members

        public void AddLayoutManager(IGridLayoutManager manager)
        {
            Add(manager);
        }

        public void SetLayoutName(string layoutName)
        {
            Debug.Assert(layoutName != null, "layoutName is null");

            foreach (IGridLayoutManager manager in this)
            {
                manager.LayoutName = layoutName;
            }
        }

        public void SaveLayouts()
        {
            foreach (IGridLayoutManager manager in this)
            {
                manager.SaveLayout();
            }
        }

        public void RestoreLayouts()
        {
            foreach (IGridLayoutManager manager in this)
            {
                manager.RestoreLayout();
            }
        }

        public void ResetLayouts()
        {
            foreach (IGridLayoutManager manager in this)
            {
                manager.ResetLayout();
            }
        }

        public void SaveLayout(string layoutName)
        {
            SetLayoutName(layoutName);
            SaveLayouts();
        }

        public void RestoreLayout(string layoutName)
        {
            if (layoutName.Equals(DefaultLayouts.Reset))
            {
                ResetLayouts();
            }
            else
            {
                SetLayoutName(layoutName);
                RestoreLayouts();
            }
        }

        #endregion
    }
}