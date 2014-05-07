using System;
using System.Collections.Generic;
using System.Diagnostics;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PhuLiNet.Business.Common.Unit;
using Techical.Dynamic.Property;
using Techical.Dynamic.Property.Sorting;
using Technical.Utilities.Exceptions;

namespace Windows.Core.Dynamic
{
    public class DynamicGridHelper
    {
        public static void AddDynamicColumns(GridView gridView, IDynamicPropertyList propertyList)
        {
            AddDynamicColumns(gridView, propertyList, true);
        }

        private static void AddDynamicColumns(GridView gridView, IDynamicPropertyList propertyList, bool addFilter)
        {
            gridView.BeginDataUpdate();

            int visibleIndexValue = 0;

            foreach (GridColumn column in gridView.Columns)
            {
                if (column.VisibleIndex > visibleIndexValue)
                    visibleIndexValue = column.VisibleIndex;
            }

            foreach (IDynamicProperty property in propertyList.GetProperties(true))
            {
                var newColumn = new GridColumn();
                newColumn.Caption = property.DisplayName;
                newColumn.FieldName = property.Key;
                newColumn.Name = "col" + property.Key;
                newColumn.OptionsColumn.ReadOnly = property.ReadOnly;
                newColumn.Visible = property.Visible;
                newColumn.ToolTip = property.Description;
                newColumn.OptionsFilter.AllowFilter = addFilter;

                if (property.Visible)
                {
                    visibleIndexValue++;
                    newColumn.VisibleIndex = visibleIndexValue;
                }
                else
                    newColumn.VisibleIndex = -1;

                newColumn.Tag = property.Key;
                newColumn.UnboundType = GetUnboundType(property);

                //check if column exists
                foreach (GridColumn column in gridView.Columns)
                {
                    Debug.Assert(column.Name != newColumn.Name, "Column with this name exists already");
                }

                gridView.Columns.Add(newColumn);
            }
            gridView.EndDataUpdate();
        }

        public static void AddDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList)
        {
            AddDynamicColumns(gridView, propertyList, ESortBy.None, ESortDirection.Ascending, null, null, true);
        }

        public static void AddDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList, ESortBy sortBy)
        {
            AddDynamicColumns(gridView, propertyList, sortBy, ESortDirection.Ascending, null, null, true);
        }

        public static void AddDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList, ESortBy sortBy,
            ESortDirection sortDir, string nullText)
        {
            AddDynamicColumns(gridView, propertyList, sortBy, sortDir, nullText, null, true);
        }

        public static void AddDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList,
            IComparer<IDynamicProperty> comparer)
        {
            AddDynamicColumns(gridView, propertyList, ESortBy.Custom, ESortDirection.None, null, comparer, true);
        }

        public static void AddDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList,
            IComparer<IDynamicProperty> comparer, string nullText)
        {
            AddDynamicColumns(gridView, propertyList, ESortBy.Custom, ESortDirection.None, nullText, comparer, true);
        }

        private static void AddDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList, ESortBy sortBy,
            ESortDirection sortDir, string nullText, IComparer<IDynamicProperty> comparer, bool allowFilter)
        {
            RepositoryItemTextEdit riteCol = null;

            gridView.BeginDataUpdate();
            int visibleIndexValue = 0;

            foreach (GridColumn column in gridView.Columns)
            {
                if (column.VisibleIndex > visibleIndexValue)
                    visibleIndexValue = column.VisibleIndex;
            }

            if (!string.IsNullOrEmpty(nullText))
            {
                riteCol = new RepositoryItemTextEdit();
                riteCol.NullText = nullText;
            }

            List<IDynamicProperty> propertyListSorted;

            if (comparer == null)
            {
                propertyListSorted = propertyList.GetPropertiesSorted(true, sortBy, sortDir);
            }
            else
            {
                propertyListSorted = propertyList.GetPropertiesSorted(true, comparer);
            }

            foreach (IDynamicProperty property in propertyListSorted)
            {
                var newColumn = new GridColumn();

                newColumn.Caption = property.DisplayName;
                newColumn.FieldName = property.Key;
                newColumn.Name = "col" + property.Key;
                newColumn.OptionsColumn.ReadOnly = property.ReadOnly;
                newColumn.Visible = property.Visible;
                newColumn.ToolTip = property.Description;
                newColumn.OptionsFilter.AllowFilter = allowFilter;
                if (riteCol != null)
                {
                    newColumn.ColumnEdit = riteCol;
                }

                if (property.Visible)
                {
                    visibleIndexValue++;
                    newColumn.VisibleIndex = visibleIndexValue;
                }
                else
                    newColumn.VisibleIndex = -1;

                newColumn.Tag = property.Key;
                newColumn.UnboundType = GetUnboundType(property);

                //check if column exists
                foreach (GridColumn column in gridView.Columns)
                {
                    Debug.Assert(column.Name != newColumn.Name, "Column with this name exists already");
                }

                gridView.Columns.Add(newColumn);
            }
            gridView.EndDataUpdate();
        }

        private static UnboundColumnType GetUnboundType(IDynamicProperty property)
        {
            UnboundColumnType unboundType;
            if (property.GetPropertyType() == typeof (string))
            {
                unboundType = UnboundColumnType.String;
            }
            else if (property.GetPropertyType() == typeof (double))
            {
                unboundType = UnboundColumnType.Decimal;
            }
            else if (property.GetPropertyType() == typeof (double?))
            {
                unboundType = UnboundColumnType.Decimal;
            }
            else if (property.GetPropertyType() == typeof (decimal))
            {
                unboundType = UnboundColumnType.Decimal;
            }
            else if (property.GetPropertyType() == typeof (decimal?))
            {
                unboundType = UnboundColumnType.Decimal;
            }
            else if (property.GetPropertyType() == typeof (int))
            {
                unboundType = UnboundColumnType.Integer;
            }
            else if (property.GetPropertyType() == typeof (int?))
            {
                unboundType = UnboundColumnType.Integer;
            }
            else if (property.GetPropertyType() == typeof (DateTime))
            {
                unboundType = UnboundColumnType.DateTime;
            }
            else if (property.GetPropertyType() == typeof (DateTime?))
            {
                unboundType = UnboundColumnType.DateTime;
            }
            else if (property.GetPropertyType() == typeof (bool))
            {
                unboundType = UnboundColumnType.Boolean;
            }
            else if (property.GetPropertyType() == typeof (object))
            {
                unboundType = UnboundColumnType.Object;
            }
            else
            {
                throw new PhuLiException(string.Format("Type [{0}] not handled. Please add this type to the function.",
                    property.GetPropertyType().FullName));
            }

            return unboundType;
        }

        public static void RemoveDynamicColumns(ColumnView gridView, IDynamicPropertyList propertyList)
        {
            gridView.BeginDataUpdate();

            foreach (IDynamicProperty p in propertyList.GetProperties(true))
            {
                GridColumn foundColumn = null;

                foreach (GridColumn column in gridView.Columns)
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
                    gridView.Columns.Remove(foundColumn);
                    foundColumn.Dispose();
                }
            }
            gridView.EndDataUpdate();
        }

        public static void GetUnboundColumnData(CustomColumnDataEventArgs e,
            IDictionary<string, IDynamicPropertyList> propertyDictionary)
        {
            if (propertyDictionary == null) return;

            var bandedColumn = e.Column as BandedGridColumn;
            if (bandedColumn == null) throw new ArgumentException("Only possible with column of type BandedGridColumn");

            var band = bandedColumn.OwnerBand;
            var bandKey = band.Tag.ToString();
            if (propertyDictionary.ContainsKey(bandKey))
            {
                DynamicBandedGridHelper.GetUnboundColumnData(e, propertyDictionary[bandKey]);
            }
        }

        public static void GetUnboundColumnData(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList)
        {
            if (propertyList != null)
            {
                if (e.IsGetData)
                {
                    if (propertyList.HasProperty(e.Column.FieldName))
                    {
                        if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (string))
                        {
                            e.Value = propertyList.GetValue<string>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (double))
                        {
                            e.Value = propertyList.GetValue<double>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (double?))
                        {
                            e.Value = propertyList.GetValue<double?>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (decimal))
                        {
                            e.Value = propertyList.GetValue<decimal>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (decimal?))
                        {
                            e.Value = propertyList.GetValue<decimal?>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (int))
                        {
                            e.Value = propertyList.GetValue<int>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (int?))
                        {
                            e.Value = propertyList.GetValue<int?>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (DateTime))
                        {
                            e.Value = propertyList.GetValue<DateTime>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (DateTime?))
                        {
                            e.Value = propertyList.GetValue<DateTime?>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (Quantity))
                        {
                            e.Value = propertyList.GetValue<Quantity>(e.Column.FieldName);
                        }
                        else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (bool))
                        {
                            e.Value = propertyList.GetValue<bool>(e.Column.FieldName);
                        }
                        else
                        {
                            throw new PhuLiException(
                                string.Format("Type [{0}] not handled. Please add this type to the function.",
                                    propertyList.GetPropertyType(e.Column.FieldName)));
                        }
                    }
                    else
                    {
                        Debug.Assert(false, string.Format("Property [{0}] not found in list", e.Column.FieldName));
                    }
                }
                else if (e.IsSetData)
                {
                    throw new PhuLiException("Please call SetUnboundColumnData");
                }
            }
        }

        public static void GetUnboundColumnData<T>(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList,
            string propertyName)
        {
            if (e.IsGetData)
            {
                if (propertyList.HasProperty(e.Column.FieldName))
                {
                    var childPropertyList = propertyList.GetProperty(e.Column.FieldName) as IDynamicPropertyList;

                    if (childPropertyList != null)
                    {
                        e.Value = childPropertyList.GetValue<T>(propertyName);
                    }
                    else
                    {
                        throw new PhuLiException("Type not handled. Please add this type to the function.");
                    }
                }
                else
                {
                    e.Value = null;
                }
            }
            else if (e.IsSetData)
            {
                throw new PhuLiException("Please call SetUnboundColumnData");
            }
        }

        public static void SetUnboundColumnData(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList)
        {
            SetUnboundColumnData(e, propertyList, true);
        }

        public static void SetUnboundColumnData(CustomColumnDataEventArgs e, IDynamicPropertyList propertyList,
            bool allowNullValue)
        {
            if (e.IsGetData)
            {
                throw new PhuLiException("Please call GetUnboundColumnData");
            }
            if (e.IsSetData)
            {
                if (propertyList.HasProperty(e.Column.FieldName))
                {
                    if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (string))
                    {
                        propertyList.SetValue(e.Column.FieldName, Convert.ToString(e.Value));
                        //get value from property, to reflect changes during set function
                        e.Value = propertyList.GetValue<string>(e.Column.FieldName);
                    }
                    else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (double))
                    {
                        if (e.Value != null)
                        {
                            double newValue;
                            bool parseOk = double.TryParse(e.Value.ToString(), out newValue);
                            if (parseOk)
                            {
                                propertyList.SetValue(e.Column.FieldName, newValue);
                                //get value from property, to reflect changes during set function
                                e.Value = propertyList.GetValue<double>(e.Column.FieldName);
                            }
                        }
                    }
                    else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (decimal))
                    {
                        if (e.Value != null)
                        {
                            decimal newValue;
                            bool parseOk = decimal.TryParse(e.Value.ToString(), out newValue);
                            if (parseOk)
                            {
                                propertyList.SetValue(e.Column.FieldName, newValue);
                                //get value from property, to reflect changes during set function
                                e.Value = propertyList.GetValue<decimal>(e.Column.FieldName);
                            }
                        }
                    }
                    else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (int))
                    {
                        if (e.Value != null)
                        {
                            int newValue;
                            bool parseOk = int.TryParse(e.Value.ToString(), out newValue);
                            if (parseOk)
                            {
                                propertyList.SetValue(e.Column.FieldName, newValue);
                                //get value from property, to reflect changes during set function
                                e.Value = propertyList.GetValue<int>(e.Column.FieldName);
                            }
                        }
                    }
                    else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (Quantity))
                    {
                        if (e.Value != null)
                        {
                            var oldQty = propertyList.GetValue<Quantity>(e.Column.FieldName);
                            Quantity newQty = Quantity.TryConvert(oldQty, e.Value);

                            if (!allowNullValue)
                            {
                                if (newQty == null && oldQty != null)
                                {
                                    newQty = Quantity.TryConvert(oldQty, 0m);
                                }
                            }

                            propertyList.SetValue(e.Column.FieldName, newQty);
                            //get value from property, to reflect changes during set function
                            e.Value = propertyList.GetValue<Quantity>(e.Column.FieldName);
                        }
                    }
                    else if (propertyList.GetPropertyType(e.Column.FieldName) == typeof (DateTime) ||
                             propertyList.GetPropertyType(e.Column.FieldName) == typeof (DateTime?))
                    {
                        if (e.Value != null)
                        {
                            DateTime newValue;
                            bool parseOk = DateTime.TryParse(e.Value.ToString(), out newValue);
                            if (parseOk)
                            {
                                propertyList.SetValue(e.Column.FieldName, newValue);
                                //get value from property, to reflect changes during set function
                                e.Value = propertyList.GetValue<DateTime>(e.Column.FieldName);
                            }
                        }
                    }
                    else
                    {
                        throw new PhuLiException(
                            string.Format("Type [{0}] not handled. Please add this type to the function.",
                                propertyList.GetPropertyType(e.Column.FieldName)));
                    }
                }
                else
                {
                    Debug.Assert(false, "Property doesn't exist in dynamic property list.");
                }
            }
        }
    }
}