using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PhuLiNet.Business.Common.CslaBase;
using Technical.Utilities.Exceptions;

namespace Windows.Core.DxExtensions
{
    public static class GridExtensions
    {
        public static void SetReadOnlyStyle(this GridControl control)
        {
            var gridSkin = GridSkins.GetSkin(control.LookAndFeel.ActiveLookAndFeel);

            var commonSkin = CommonSkins.GetSkin(control.LookAndFeel.ActiveLookAndFeel);
            if (commonSkin == null)
            {
                return;
            }

            var bgColor = commonSkin.Colors.GetColor(CommonColors.ReadOnly);
            var foreColor = Color.DimGray;

            foreach (var view in control.Views.OfType<ColumnView>())
            {
                foreach (GridColumn column in view.Columns)
                {
                    if (!column.OptionsColumn.AllowEdit || column.OptionsColumn.ReadOnly)
                    {
                        column.OptionsColumn.AllowEdit = false;
                        column.OptionsColumn.ReadOnly = true;

                        column.AppearanceCell.BackColor = bgColor;
                        column.AppearanceCell.Options.UseBackColor = true;

                        column.AppearanceCell.ForeColor = foreColor;
                        column.AppearanceCell.Options.UseForeColor = true;
                    }
                }

                var gridView = view as GridView;
                if (gridView != null && gridSkin != null)
                {
                    gridView.CustomDrawCell += (sender, args) => DrawDefault(args, gridSkin);
                }
            }
        }

        private static void DrawDefault(RowCellCustomDrawEventArgs e, Skin currentSkin)
        {
            if (e.RowHandle != GridControl.AutoFilterRowHandle)
                return;

            var skinElement = currentSkin[GridSkins.SkinGridRow];
            e.Appearance.BackColor = skinElement.Color.BackColor;
            e.Appearance.ForeColor = skinElement.Color.ForeColor;
        }


        /// <summary>
        /// Force navigation to business object in the main view of given grid control.
        /// If filter is activated and hides the row, the filter will be cleared before navigation.
        /// </summary>
        /// <typeparam name="T">type of business object (element in list)</typeparam>
        /// <param name="gridControl">the dev express grid control</param>
        /// <param name="idOfBoToFocus">id value of business object to focus</param>
        public static void ForceNavigate<T>(this GridControl gridControl, object idOfBoToFocus)
            where T : class, IPhuLiBusinessBase
        {
            ForceNavigate<T>(gridControl, p => p.IdValue.Equals(idOfBoToFocus));
        }

        /// <summary>
        /// Force navigation to the first row in the main view of given grid control which satisfy the given predicate.
        /// If filter is activated and hides the row, the filter will be cleared before navigation.
        /// </summary>
        /// <typeparam name="T">type of list element</typeparam>
        /// <param name="gridControl">the dev express grid control</param>
        /// <param name="predicate">the predicate to get the row to focus</param>
        public static void ForceNavigate<T>(this GridControl gridControl, Func<T, bool> predicate)
        {
            # region find data source index

            var bindingSource = gridControl.DataSource as BindingSource;
            if (bindingSource == null)
                throw new PhuLiException("binding source may not be null");
            var dataSource = bindingSource.DataSource as IEnumerable<T>;
            if (dataSource == null)
                throw new PhuLiException(
                    "data source must be of type IEnumerable<IPhuLiBusinessBase> and may not be null");
            var gridView = gridControl.MainView as GridView;
            if (gridView == null)
                throw new PhuLiException("main view of grid control may not be null");

            // find index of business object in data source to navigate to
            var boToNavigate = dataSource.FirstOrDefault(predicate);
            if (Equals(boToNavigate, default(T)))
                return;

            var dataSourceIndex = bindingSource.IndexOf(boToNavigate);

            #endregion

            #region navigate to business object

            var rowHandle = gridView.GetRowHandle(dataSourceIndex);

            // row is hidden and filter is active: clear filter
            if (gridView.IsRowVisible(rowHandle) == RowVisibleState.Hidden && !gridView.ActiveFilter.IsEmpty)
            {
                gridView.ActiveFilter.Clear();
                rowHandle = gridView.GetRowHandle(dataSourceIndex);
            }

            gridView.FocusedRowHandle = rowHandle;

            #endregion
        }
    }
}