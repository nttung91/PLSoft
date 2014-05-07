using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Core.Dynamic;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using PhuLiNet.Business.Common.Unit;
using Techical.Dynamic.Property;
using Technical.Utilities.Exceptions;

namespace Windows.Core.Dynamic
{
    public class DynamicBandedGridHelper
    {
        public static void AddDynamicColumns(IGridCreateParameters gridCreateParameter)
        {
            if (gridCreateParameter.HeaderList == null) throw new ArgumentException("HeaderList required");
            if (gridCreateParameter.ExistingBand == null) throw new ArgumentException("ExistingBand required");

            var view = gridCreateParameter.GetView();
            if (view == null) throw new ArgumentException("View required");

            view.BeginDataUpdate();
            var visibleIndexValue = 0;

            foreach (GridColumn column in gridCreateParameter.ExistingBand.Columns)
            {
                if (column.VisibleIndex > visibleIndexValue)
                    visibleIndexValue = column.VisibleIndex;
            }

            var propertyListSorted = GetComparer(gridCreateParameter);

            try
            {
                foreach (IDynamicProperty property in propertyListSorted)
                {
                    var newColumn = CreateColumn(property, ref visibleIndexValue,
                        gridCreateParameter.Options.ColumnOptions);
                    gridCreateParameter.ExistingBand.Columns.Add(newColumn);
                    CreateFilterCriteria(property, newColumn);
                }
            }
            finally
            {
                view.EndDataUpdate();
            }
        }

        public static void AddDynamicBand(IGridCreateParameters gridCreateParameter)
        {
            if (gridCreateParameter.HeaderList == null) throw new ArgumentException("HeaderList required");
            if (gridCreateParameter.ExistingGridView == null) throw new ArgumentException("ExistingGridView required");
            if (gridCreateParameter.Options.BandOptions.BandIdentifier == null)
                throw new ArgumentException("BandIdentifier required");
            if (gridCreateParameter.ExistingBand != null &&
                !ReferenceEquals(gridCreateParameter.ExistingGridView, gridCreateParameter.ExistingBand.View))
                throw new ArgumentException(
                    "View from Band does not match ExistingGridView. Wrong view or wrong band used.");

            var view = gridCreateParameter.GetView();
            view.BeginDataUpdate();

            try
            {
                var newChildBand = new GridBand
                {
                    Tag = gridCreateParameter.Options.BandOptions.BandIdentifier.Key,
                    Caption = gridCreateParameter.Options.BandOptions.BandIdentifier.DisplayName,
                    ToolTip = gridCreateParameter.Options.BandOptions.BandIdentifier.Description
                };
                newChildBand.AppearanceHeader.TextOptions.HAlignment = gridCreateParameter.Options.BandOptions.HorzAlign;
                newChildBand.AppearanceHeader.Options.UseTextOptions = true;

                if (gridCreateParameter.ExistingBand != null)
                {
                    gridCreateParameter.ExistingBand.Children.Add(newChildBand);
                }
                else
                {
                    gridCreateParameter.ExistingGridView.Bands.Add(newChildBand);
                }

                var visibleIndexValue = 0;
                foreach (GridColumn column in newChildBand.Columns)
                {
                    if (column.VisibleIndex > visibleIndexValue)
                        visibleIndexValue = column.VisibleIndex;
                }

                var propertyListSorted = GetComparer(gridCreateParameter);
                foreach (IDynamicProperty property in propertyListSorted)
                {
                    var newColumn = CreateColumn(property, ref visibleIndexValue,
                        gridCreateParameter.Options.ColumnOptions);
                    newChildBand.Columns.Add(newColumn);
                    CreateFilterCriteria(property, newColumn);
                }
            }
            finally
            {
                view.EndDataUpdate();
            }
        }

        private static void CreateFilterCriteria(IDynamicProperty property, BandedGridColumn column)
        {
            if (property.FilterCriteria == null || string.IsNullOrEmpty(property.FilterCriteria.FilterString))
                return;
            var filterInfo = new ColumnFilterInfo(property.FilterCriteria.FilterString);
            column.FilterInfo = filterInfo;
        }

        private static BandedGridColumn CreateColumn(IDynamicProperty property, ref int visibleIndexValue,
            ColumnOptions columnOptions)
        {
            var newColumn = new BandedGridColumn();
            var isNumeric = true;

            newColumn.Caption = property.DisplayName;
            newColumn.FieldName = property.Key;
            newColumn.Name = "col" + property.Key;
            newColumn.OptionsColumn.ReadOnly = property.ReadOnly;
            newColumn.Visible = property.Visible;
            newColumn.Tag = property.Key;
            newColumn.ToolTip = property.Description;
            newColumn.OptionsColumn.AllowSort = columnOptions.AllowSort;
            newColumn.OptionsFilter.AllowFilter = columnOptions.AllowFilter;

            if (columnOptions.MinWidth.HasValue)
                newColumn.MinWidth = columnOptions.MinWidth.Value;

            if (columnOptions.ColumnEdit != null)
                newColumn.ColumnEdit = columnOptions.ColumnEdit;

            if (columnOptions.HorzAlign.HasValue)
            {
                newColumn.AppearanceCell.Options.UseTextOptions = true;
                newColumn.AppearanceCell.TextOptions.HAlignment = columnOptions.HorzAlign.Value;
                newColumn.AppearanceHeader.Options.UseTextOptions = true;
                newColumn.AppearanceHeader.TextOptions.HAlignment = columnOptions.HorzAlign.Value;
            }

            if (columnOptions.SummaryType == SummaryItemType.Custom)
            {
                newColumn.AppearanceHeader.Options.UseTextOptions = true;
                if (columnOptions.HorzAlign.HasValue)
                {
                    newColumn.AppearanceHeader.TextOptions.HAlignment = columnOptions.HorzAlign.Value;
                }
            }

            if (newColumn.Visible)
            {
                visibleIndexValue++;
                newColumn.VisibleIndex = visibleIndexValue;
                newColumn.ColVIndex = visibleIndexValue;
            }
            else
            {
                newColumn.VisibleIndex = -1;
                newColumn.ColVIndex = -1;
            }

            if (property.GetPropertyType() == typeof (string))
            {
                newColumn.UnboundType = UnboundColumnType.String;
                isNumeric = false;
            }
            else if (property.GetPropertyType() == typeof (double))
            {
                newColumn.UnboundType = UnboundColumnType.Integer;
            }
            else if (property.GetPropertyType() == typeof (decimal))
            {
                newColumn.DisplayFormat.FormatString = "{0:n2}";
                newColumn.DisplayFormat.FormatType = FormatType.Numeric;
                newColumn.UnboundType = UnboundColumnType.Decimal;
            }
            else if (property.GetPropertyType() == typeof (decimal?))
            {
                newColumn.DisplayFormat.FormatString = "{0:n2}";
                newColumn.DisplayFormat.FormatType = FormatType.Numeric;
                newColumn.UnboundType = UnboundColumnType.Decimal;
            }
            else if (property.GetPropertyType() == typeof (int))
            {
                newColumn.DisplayFormat.FormatString = "{0:n0}";
                newColumn.DisplayFormat.FormatType = FormatType.Numeric;
                newColumn.UnboundType = UnboundColumnType.Integer;
            }
            else if (property.GetPropertyType() == typeof (int?))
            {
                newColumn.DisplayFormat.FormatString = "{0:n0}";
                newColumn.DisplayFormat.FormatType = FormatType.Numeric;
                newColumn.UnboundType = UnboundColumnType.Integer;
            }
            else if (property.GetPropertyType() == typeof (Quantity))
            {
                newColumn.DisplayFormat.FormatType = FormatType.None;
                newColumn.UnboundType = UnboundColumnType.Object;
            }
            else if (property.GetPropertyType() == typeof (DateTime) || property.GetPropertyType() == typeof (DateTime?))
            {
                // Wenn nur der Datumsanteil angezeigt werden soll, muss Value ein Datum ohne Uhrzeit haben.
                isNumeric = false;
                var d = property.Value as DateTime?;
                newColumn.DisplayFormat.FormatType = FormatType.DateTime;
                if (d != null && d.Value == d.Value.Date)
                {
                    newColumn.DisplayFormat.FormatString = "d"; // Nur Datum
                }
                else
                {
                    newColumn.DisplayFormat.FormatString = "g"; // Default: Datum und Zeit.
                }
                newColumn.UnboundType = UnboundColumnType.DateTime;
            }
            else if (property.GetPropertyType() == typeof (bool))
            {
                newColumn.UnboundType = UnboundColumnType.Boolean;
            }
            else
            {
                throw new PhuLiException(
                    string.Format("Type [{0}] not handled. Please add this type to the function.",
                        property.GetPropertyType().FullName));
            }

            if (!string.IsNullOrEmpty(columnOptions.DisplayFormatString))
            {
                newColumn.DisplayFormat.FormatString = columnOptions.DisplayFormatString;
            }

            if (columnOptions.DisplayFormatType != null)
            {
                newColumn.DisplayFormat.FormatType = FormatType.Numeric;
            }

            if (isNumeric)
            {
                if (columnOptions.SummaryType != SummaryItemType.None)
                {
                    newColumn.SummaryItem.SummaryType = columnOptions.SummaryType;
                    newColumn.SummaryItem.DisplayFormat = "{0:n0}";
                }
            }
            return newColumn;
        }

        public static void RemoveDynamicColumns(GridBand onThisBand, IDynamicPropertyList propertyList)
        {
            if (onThisBand.View == null) return;

            onThisBand.View.BeginDataUpdate();
            foreach (IDynamicProperty p in propertyList.GetProperties(true))
            {
                BandedGridColumn foundColumn = null;

                foreach (BandedGridColumn column in onThisBand.Columns)
                {
                    if (column.Tag != null)
                    {
                        var keyValue = column.Tag as string;

                        if (keyValue != null)
                        {
                            if (keyValue == p.Key)
                            {
                                foundColumn = column;
                            }
                        }
                    }
                }

                if (foundColumn != null)
                {
                    onThisBand.Columns.Remove(foundColumn);
                    foundColumn.Dispose();
                }
            }
            onThisBand.View.EndDataUpdate();
        }

        public static void RemoveDynamicBand(BandedGridView onThisView, BandOptions bandOptions)
        {
            if (onThisView == null) throw new ArgumentException("View required");
            if (bandOptions.BandIdentifier == null) throw new ArgumentException("BandIdentifier required");

            onThisView.BeginDataUpdate();

            GridBand bandToDelete = null;
            foreach (GridBand childBand in onThisView.Bands)
            {
                if (childBand.Tag != null)
                {
                    var keyValue = childBand.Tag as string;
                    if (keyValue == bandOptions.BandIdentifier.Key)
                    {
                        bandToDelete = childBand;
                        break;
                    }
                }
            }

            if (bandToDelete != null)
            {
                for (int i = bandToDelete.Columns.Count - 1; i >= 0; i--)
                {
                    bandToDelete.Columns.RemoveAt(i);
                }
                onThisView.Bands.Remove(bandToDelete);
            }

            onThisView.EndDataUpdate();
        }

        public static void RemoveDynamicBand(GridBand onThisBand, BandOptions bandOptions)
        {
            if (onThisBand == null) throw new ArgumentException("ExistingBand required");
            if (onThisBand.View == null) throw new ArgumentException("ExistingBand.View required");
            if (bandOptions.BandIdentifier == null) throw new ArgumentException("BandIdentifier required");

            onThisBand.View.BeginDataUpdate();

            GridBand bandToDelete = null;
            foreach (GridBand childBand in onThisBand.Children)
            {
                if (childBand.Tag != null)
                {
                    var keyValue = childBand.Tag as string;
                    if (keyValue == bandOptions.BandIdentifier.Key)
                    {
                        bandToDelete = childBand;
                        break;
                    }
                }
            }

            if (bandToDelete != null)
            {
                for (int i = bandToDelete.Columns.Count - 1; i >= 0; i--)
                {
                    bandToDelete.Columns.RemoveAt(i);
                }
                onThisBand.Children.Remove(bandToDelete);
            }

            onThisBand.View.EndDataUpdate();
        }

        public static void AddDynamicBandsAndColumnsViaGroupCriteria(IGridCreateParameters gridCreateParameter)
        {
            if (gridCreateParameter.HeaderList == null) throw new ArgumentException("HeaderList required");
            if (gridCreateParameter.ExistingBand == null) throw new ArgumentException("ExistingBand required");

            var view = gridCreateParameter.GetView();
            if (view == null) throw new ArgumentException("View required");
            view.BeginDataUpdate();

            var propertyListSorted = GetComparer(gridCreateParameter);

            try
            {
                foreach (IDynamicProperty property in propertyListSorted)
                {
                    Debug.Assert(property.GroupCriteria != null && property.GroupCriteria.Key != null,
                        "Group-Criteria muss gefüllt sein, sonst gibt's keine Bänder");

                    GridBand childBand = null;

                    foreach (GridBand band in gridCreateParameter.ExistingBand.Children)
                    {
                        var bandName = band.Tag as string;

                        if (bandName == property.GroupCriteria.Key)
                        {
                            childBand = band;
                            break;
                        }
                    }
                    if (childBand == null)
                    {
                        childBand = new GridBand
                        {
                            Tag = property.GroupCriteria.Key,
                            Caption = property.GroupCriteria.DisplayName,
                            ToolTip = property.GroupCriteria.Description
                        };

                        gridCreateParameter.ExistingBand.Children.Add(childBand);
                    }
                    var visibleIndexValue = 0;
                    foreach (GridColumn column in childBand.Columns)
                    {
                        if (column.VisibleIndex > visibleIndexValue)
                            visibleIndexValue = column.VisibleIndex;
                    }

                    var newColumn = CreateColumn(property, ref visibleIndexValue,
                        gridCreateParameter.Options.ColumnOptions);
                    childBand.Columns.Add(newColumn);
                    CreateFilterCriteria(property, newColumn);
                }
            }
            finally
            {
                view.EndDataUpdate();
            }
        }

        private static IEnumerable<IDynamicProperty> GetComparer(IGridCreateParameters createParameter)
        {
            return createParameter.Options.BandOptions.Comparer == null
                ? createParameter.HeaderList.GetPropertiesSorted(true, createParameter.Options.BandOptions.SortBy,
                    createParameter.Options.BandOptions.SortDirection)
                : createParameter.HeaderList.GetPropertiesSorted(true, createParameter.Options.BandOptions.Comparer);
        }

        public static void RemoveDynamicBandsAndColumns(GridBand onThisBand, IDynamicPropertyList headerList)
        {
            if (onThisBand.View == null) return;

            onThisBand.View.BeginDataUpdate();
            foreach (IDynamicProperty header in headerList.GetProperties(true))
            {
                BandedGridColumn foundColumn = null;
                foreach (GridBand childBand in onThisBand.Children)
                {
                    foreach (BandedGridColumn column in childBand.Columns)
                    {
                        if (column.Tag != null)
                        {
                            var keyValue = column.Tag as string;

                            if (keyValue != null && keyValue == header.Key)
                            {
                                foundColumn = column;
                                break;
                            }
                        }
                    }

                    if (foundColumn != null)
                    {
                        childBand.Columns.Remove(foundColumn);
                        foundColumn.Dispose();
                        break;
                    }
                }

                // Jetzt noch die Nutzlosen Bänder entfernen.
                // Das machen wir mit der üblichen EntfernungsTaktik: Von hinten nach vorne, damit wir uns nicht den Boden unter den Füssen wegziehen.
                // (Foreach geht sowieso nicht)
                for (int i = onThisBand.Children.Count - 1; i >= 0; i--)
                {
                    if (onThisBand.Children[i].Columns.Count == 0)
                        onThisBand.Children.Remove(onThisBand.Children[i]);
                }
            }
            onThisBand.View.EndDataUpdate();
        }

        // --------------------------------------------------------------------------------------------------------------------

        public static void GetUnboundColumnData<T>(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList,
            string propertyName)
        {
            DynamicGridHelper.GetUnboundColumnData<T>(e, propertyList, propertyName);
        }

        public static void SetUnboundColumnData(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList)
        {
            DynamicGridHelper.SetUnboundColumnData(e, propertyList, true);
        }

        public static void SetUnboundColumnData(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList,
            bool allowNullValue)
        {
            DynamicGridHelper.SetUnboundColumnData(e, propertyList, allowNullValue);
        }

        public static void GetUnboundColumnData(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList)
        {
            DynamicGridHelper.GetUnboundColumnData(e, propertyList);
        }

        public static void GetUnboundColumnData(CustomColumnDataEventArgs e,
            IDictionary<string, IDynamicPropertyList> propertyDictionary)
        {
            DynamicGridHelper.GetUnboundColumnData(e, propertyDictionary);
        }
    }
}