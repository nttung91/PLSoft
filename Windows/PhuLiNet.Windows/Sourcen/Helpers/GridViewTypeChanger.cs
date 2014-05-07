using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;

namespace Windows.Core.Helpers
{
    /// <summary>
    /// Dieser Helper ermöglicht es, zur Laufzeit einen GridView in einen anderen Typ zu ändern.
    /// Basiert auf einem Beispiel von DevExpress, siehe http://devexpress.com/Support/Center/p/Q217339.aspx
    /// </summary>
    public static class GridViewTypeChanger
    {
        public const string CardView = "CardView";
        public const string GridView = "GridView";
        public const string LayoutView = "LayoutView";

        /// <summary>
        /// MainView eines GridControls auf GridView ändern.
        /// </summary>
        /// <param name="grid">Das Grid, für den der View geändert werden soll</param>
        /// <returns>Der erstellte View</returns>
        public static GridView CreateGridView(GridControl grid)
        {
            return (GridView) CreateView(grid, grid.LevelTree, GridView, false);
        }

        /// <summary>
        /// MainView eines GridControls auf CardView ändern
        /// </summary>
        /// <param name="grid">Das Grid, für den der View geändert werden soll</param>
        /// <returns>Der erstellte View</returns>
        public static CardView CreateCardView(GridControl grid)
        {
            var view = (CardView) CreateView(grid, grid.LevelTree, CardView, false);
            if (view != null)
            {
                view.OptionsView.ShowEmptyFields = true;
                view.MaximumCardRows = 1;
                view.CardWidth = 300;
            }
            return view;
        }

        /// <summary>
        /// MainView eines GridControls auf LayoutView ändern
        /// </summary>
        /// <param name="grid">Das Grid, für den der View geändert werden soll</param>
        /// <returns>Der erstellte View</returns>
        public static LayoutView CreateLayoutView(GridControl grid)
        {
            var view = (LayoutView) CreateView(grid, grid.LevelTree, LayoutView, false);
            if (view != null)
            {
                view.CardMinSize = new Size(400, 500);
            }
            return view;
        }

        /// <summary>
        /// MainView eines GridControls ändern
        /// </summary>
        /// <param name="grid">Das Grid, für den der View geändert werden soll</param>
        /// <param name="viewName">Name (Typ) des neuen Views.</param>
        /// <returns>Der erstellte View</returns>
        public static BaseView CreateView(GridControl grid, string viewName)
        {
            return CreateView(grid, grid.LevelTree, viewName, false);
        }

        /// <summary>
        /// Einen View eines GridControls ändern
        /// </summary>
        /// <param name="grid">Das Grid, für den der View geändert werden soll</param>
        /// <param name="node">Der Node innerhalb der View-Hiearchie, für den der View geändert werden soll.</param>
        /// <param name="viewName">Name (Typ) des neuen Views.</param>
        /// <param name="removeOld"></param>
        /// <returns>Der erstellte View</returns>
        public static BaseView CreateView(GridControl grid, GridLevelNode node, string viewName, bool removeOld)
        {
            if (node == null) return null;

            // View schoh da.
            BaseView previousView = node.LevelTemplate;
            if (previousView is GridView)
            {
                var gv = previousView as GridView;
                gv.GroupCount = 0;
                // gv.FilteredColumnsCount = 0;
            }


            // Neuen View erzeugen
            BaseView newView = grid.CreateView(viewName);
            Debug.Assert(newView != null, "View " + viewName + " konnte nicht angelegt werden.");
            grid.ViewCollection.Add(newView);

            // Layout des alten Views sichern.
            previousView = node.LevelTemplate;
            MemoryStream ms = null;
            if (previousView != null)
            {
                ms = new MemoryStream();
                previousView.SaveLayoutToStream(ms, OptionsLayoutBase.FullLayout);
            }

            // Dem Node den neuen View zuweisen.
            ChangeView(grid, node, newView);

            if (ms != null)
            {
                ms.Seek(0, SeekOrigin.Begin);
                newView.RestoreLayoutFromStream(ms, OptionsLayoutBase.FullLayout);
                ms.Close();

                MethodInfo mi = newView.GetType()
                    .GetMethod("DesignerMakeColumnsVisible",
                        BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null) mi.Invoke(newView, null);
                if (previousView != null) AssignViewProperties(previousView, newView);
            }
            if (removeOld && previousView != null)
                previousView.Dispose();
            return newView;
        }

        // Ein paar elementare Properties kopieren.
        private static void AssignViewProperties(BaseView prevView, BaseView newView)
        {
            ColumnView cprev = prevView as ColumnView, cview = newView as ColumnView;
            if (cprev == null || cview == null) return;

            cview.Images = cprev.Images;

            // Column-Properties
            // Anmerkung: Bei Layout-View nützt die Eigenschaft "VisibleIndex" rein gar nichts.
            foreach (GridColumn col in cprev.Columns)
            {
                GridColumn newCol = cview.Columns[col.FieldName];
                if (newCol != null)
                {
                    newCol.Visible = col.Visible;
                    newCol.VisibleIndex = col.VisibleIndex;

                    newCol.FilterInfo = col.FilterInfo;
                }
            }
        }

        /// <summary>
        /// Den Mainview austauschen.
        /// </summary>
        public static void ChangeView(GridControl grid, BaseView newView)
        {
            ChangeView(grid, grid.LevelTree, newView);
        }

        /// <summary>
        /// Den View für einen GridNode austauschen.
        /// </summary>
        public static void ChangeView(GridControl grid, GridLevelNode node, BaseView newView)
        {
            // Dem Node den neuen View zuweisen.
            if (node.IsRootLevel)
            {
                grid.MainView = newView;
            }
            else
            {
                node.LevelTemplate = newView; // Für Subview das Template ändern.
            }
        }
    }
}