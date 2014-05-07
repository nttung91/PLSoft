using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace Windows.Core.DxExtensions
{
    public static class GridBandExtensions
    {
        private const string ColumnFormat = "n0";
        private const string SummaryFormat = "{0:n0}";
        private const int InitialColumnWidth = 30;

        public static void AddUnboundBandColumns(this GridBand band,
            bool readOnly,
            int rowIndex,
            string captionFormat,
            string fieldPrefix,
            UnboundColumnType unboundColumnType,
            SummaryItemType summaryType,
            IEnumerable<string> header,
            int? minWidth = null)
        {
            Debug.Assert(band != null && band.View != null, "band == null || band.View == null ");

            if (band == null || band.View == null) return;

            band.View.BeginUpdate();

            try
            {
                var gridColumnList = new List<BandedGridColumn>();

                foreach (var item in header)
                {
                    var fieldName = fieldPrefix + item;
                    var caption = GetCaption(captionFormat, item);

                    var column = CreateBandedGridColumn(readOnly,
                        rowIndex,
                        caption,
                        fieldName,
                        unboundColumnType,
                        summaryType,
                        HorzAlignment.Far,
                        item,
                        minWidth);

                    gridColumnList.Add(column);
                }

                band.View.Columns.AddRange(gridColumnList.ToArray());

                foreach (var gridColumn in gridColumnList)
                {
                    band.Columns.Add(gridColumn);
                }

                if (summaryType != SummaryItemType.None)
                {
                    var groupSummaryList = new List<GridGroupSummaryItem>();
                    foreach (var gridColumn in gridColumnList)
                    {
                        var gridGroupSummaryItem = new GridGroupSummaryItem(summaryType,
                            gridColumn.FieldName,
                            gridColumn,
                            SummaryFormat);

                        groupSummaryList.Add(gridGroupSummaryItem);
                    }

                    band.View.GroupSummary.AddRange(groupSummaryList.ToArray());
                }
            }
            finally
            {
                band.View.EndUpdate();
            }
        }

        public delegate string GetTooltip(string key);

        public static void AddTooltip(this GridBand gridBand, GetTooltip tooltipGetter)
        {
            Debug.Assert(gridBand != null && gridBand.View != null, "gridBand == null || gridBand.View == null ");

            if (gridBand == null || gridBand.View == null) return;

            gridBand.View.BeginDataUpdate();

            try
            {
                foreach (BandedGridColumn column in gridBand.Columns)
                {
                    column.ToolTip = tooltipGetter(column.FieldName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gridBand.View.EndDataUpdate();
            }
        }

        public static void AddGroupSummaries(this GridBand gridBand, int? rowIndex, SummaryItemType summaryType)
        {
            Debug.Assert(gridBand != null && gridBand.View != null && gridBand.View.GroupSummary != null,
                "gridBand == null || gridBand.View == null || gridBand.View.GroupSummary==null");

            if (gridBand == null || gridBand.View == null || gridBand.View.GroupSummary == null)
                return;


            gridBand.View.BeginDataUpdate();

            try
            {
                var groupSummaryList = new List<GridSummaryItem>();
                for (var i = 0; i < gridBand.Columns.Count; i++)
                {
                    if (rowIndex.HasValue && gridBand.Columns[i].RowIndex != rowIndex.Value) continue;

                    var groupSummaryItem = new GridGroupSummaryItem(summaryType,
                        gridBand.Columns[i].FieldName,
                        gridBand.Columns[i],
                        "{0:n0}");
                    groupSummaryList.Add(groupSummaryItem);
                }

                gridBand.View.GroupSummary.AddRange(groupSummaryList.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gridBand.View.EndDataUpdate();
            }
        }

        public static void AddAdvBandedGridGroupSummaries(this GridBand gridBand, int? rowIndex,
            SummaryItemType summaryType)
        {
            Debug.Assert(gridBand != null && gridBand.View != null && gridBand.View.GroupSummary != null,
                "gridBand == null || gridBand.View == null || gridBand.View.GroupSummary==null");

            if (gridBand == null || gridBand.View == null || gridBand.View.GroupSummary == null)
                return;


            gridBand.View.BeginDataUpdate();

            try
            {
                var groupSummaryList = new List<GridSummaryItem>();
                for (var i = 0; i < gridBand.Columns.Count; i++)
                {
                    if (rowIndex.HasValue && gridBand.Columns[i].RowIndex != rowIndex.Value) continue;

                    var groupSummaryItem = new GridGroupSummaryItem(summaryType,
                        gridBand.Columns[i].FieldName,
                        gridBand.Columns[i],
                        "{0:n0}");
                    groupSummaryList.Add(groupSummaryItem);
                }

                gridBand.View.GroupSummary.AddRange(groupSummaryList.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gridBand.View.EndDataUpdate();
            }
        }

        public static void RemoveGroupSummaries(this GridBand gridBand)
        {
            Debug.Assert(gridBand != null && gridBand.View != null && gridBand.View.GroupSummary != null,
                "gridBand == null || gridBand.View == null || gridBand.View.GroupSummary==null");

            if (gridBand == null || gridBand.View == null || gridBand.View.GroupSummary == null) return;

            gridBand.View.BeginDataUpdate();

            try
            {
                var gridGroupSummaryItemsToDelete = new List<GridGroupSummaryItem>();
                foreach (GridGroupSummaryItem groupSummary in gridBand.View.GroupSummary)
                {
                    var summarisedColumn = groupSummary.ShowInGroupColumnFooter as BandedGridColumn;
                    if (summarisedColumn != null && gridBand.Columns.Contains(summarisedColumn))
                    {
                        gridGroupSummaryItemsToDelete.Add(groupSummary);
                    }
                }
                foreach (GridGroupSummaryItem gridGroupSummaryItemToDelete in gridGroupSummaryItemsToDelete)
                {
                    gridBand.View.GroupSummary.Remove(gridGroupSummaryItemToDelete);
                }
            }
            finally
            {
                gridBand.View.EndDataUpdate();
            }
        }

        public static IEnumerable<BandedGridColumn> GetNumberOfVisibleColumnsInRow(this GridBand band, int rowIndex)
        {
            foreach (BandedGridColumn column in band.Columns)
            {
                if (column.Visible && column.RowIndex == rowIndex)
                    yield return column;
            }
        }

        public static int? GetMaxColumnWidth(this GridBand band, int minWidth)
        {
            int? maxWidth = null;

            foreach (BandedGridColumn column in band.Columns)
            {
                if (column.Visible)
                {
                    if (!maxWidth.HasValue)
                        maxWidth = minWidth;

                    int bestWidth = column.GetBestWidth();
                    if (maxWidth < bestWidth)
                        maxWidth = bestWidth;
                }
            }

            return maxWidth;
        }

        public static bool NeedsResize(this GridBand band, int desiredWidth)
        {
            var needsResize = false;
            foreach (BandedGridColumn column in band.Columns)
            {
                if (column.Visible && column.Width != desiredWidth)
                {
                    needsResize = true;
                    break;
                }
            }

            return needsResize;
        }

        public static void SetColumnsVisible(this GridBand band, int rowindex, bool visible)
        {
            foreach (BandedGridColumn column in band.Columns)
            {
                if (column.RowIndex == rowindex)
                {
                    column.Visible = visible;
                }
            }
        }

        public static void ClearColumns(this GridBand band)
        {
            Debug.Assert(band != null && band.View != null, "band == null || band.View == null ");

            if (band == null || band.View == null) return;


            band.View.BeginUpdate();

            try
            {
                var columnToRemove = new List<BandedGridColumn>();
                foreach (BandedGridColumn column in band.Columns)
                {
                    columnToRemove.Add(column);
                    var summaryToRemove = new List<GridGroupSummaryItem>();
                    foreach (GridGroupSummaryItem item in band.View.GroupSummary)
                    {
                        if (item.FieldName == column.FieldName)
                        {
                            summaryToRemove.Add(item);
                        }
                    }
                    foreach (var item in summaryToRemove)
                    {
                        band.View.GroupSummary.Remove(item);
                    }
                }

                foreach (BandedGridColumn column in columnToRemove)
                {
                    band.View.Columns.Remove(column);
                    band.Columns.Remove(column);
                    column.Summary.Clear();

                    column.Dispose();
                }
            }
            finally
            {
                band.View.EndUpdate();
            }
        }

        public static void ColumnBestFitToMaxWidth(this GridBand band)
        {
            if (band.Columns.Count == 0) return;
            var newColumnWidth = band.GetMaxColumnWidth(10);

            if (newColumnWidth.HasValue)
            {
                var needsResize = band.NeedsResize(newColumnWidth.Value);

                if (needsResize)
                {
                    // Gem. DX: zuerst grid Width setzen, dann alle Cols ausser der letzten, KEIN Begin/End Update machen
                    var gridColumnsInRow0 = band.GetNumberOfVisibleColumnsInRow(0);
                    var newBandWidth = gridColumnsInRow0.Count()*newColumnWidth.Value;
                    band.Resize(newBandWidth);
                    ResizeAllColumnsButLast(gridColumnsInRow0, newColumnWidth.Value);

                    var gridColumnsInRow1 = band.GetNumberOfVisibleColumnsInRow(1);
                    ResizeAllColumnsButLast(gridColumnsInRow1, newColumnWidth.Value);
                }
            }
        }

        #region Helpers

        private static string GetCaption(string captionFormat, string item)
        {
            string caption;
            if (string.IsNullOrEmpty(captionFormat))
                caption = string.Empty;
            else
                caption = string.Format(captionFormat, item);
            return caption;
        }

        private static BandedGridColumn CreateBandedGridColumn(bool readOnly,
            int rowIndex,
            string caption,
            string fieldName,
            UnboundColumnType unboundColumnType,
            SummaryItemType summaryItemType,
            HorzAlignment headerAlignment,
            object tag,
            int? minWidth)
        {
            var bandedGridColumn = new BandedGridColumn();

            bandedGridColumn.Caption = caption;
            bandedGridColumn.DisplayFormat.FormatString = ColumnFormat;
            bandedGridColumn.DisplayFormat.FormatType = FormatType.Numeric;
            bandedGridColumn.FieldName = fieldName;
            bandedGridColumn.Name = "col" + fieldName;
            bandedGridColumn.Tag = tag;

            bandedGridColumn.OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridColumn.OptionsColumn.ShowInCustomizationForm = false;
            bandedGridColumn.OptionsFilter.AllowFilter = false;
            bandedGridColumn.OptionsColumn.AllowEdit = !readOnly;
            bandedGridColumn.OptionsColumn.ReadOnly = readOnly;
            bandedGridColumn.OptionsColumn.AllowFocus = !readOnly;
            bandedGridColumn.AppearanceHeader.Options.UseTextOptions = true;
            bandedGridColumn.AppearanceHeader.TextOptions.HAlignment = headerAlignment;

            if (minWidth.HasValue)
                bandedGridColumn.MinWidth = minWidth.Value;

            bandedGridColumn.RowIndex = rowIndex;
            if (summaryItemType != SummaryItemType.None)
            {
                bandedGridColumn.Summary.AddRange(new GridSummaryItem[]
                {
                    new GridColumnSummaryItem(summaryItemType,
                        fieldName,
                        SummaryFormat)
                });
            }

            bandedGridColumn.Visible = true;
            bandedGridColumn.UnboundType = unboundColumnType;
            bandedGridColumn.Width = InitialColumnWidth;

            return bandedGridColumn;
        }

        private static void ResizeAllColumnsButLast(IEnumerable<BandedGridColumn> gridColumns, int newWidth)
        {
            var cnt = 1;
            foreach (BandedGridColumn gridColumn in gridColumns)
            {
                if (cnt++ < gridColumns.Count())
                {
                    gridColumn.Resize(newWidth);
                }
            }
        }

        #endregion
    }
}