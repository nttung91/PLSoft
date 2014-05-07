using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using PhuLiNet.Business.Common.Lookup;
using Windows.Core.BaseForms;
using Windows.Core.Dynamic;
using Windows.Core.Helpers;

namespace Windows.Core.Forms.Lookup
{
    internal partial class FrmLookupObject : FrmReadOnlyBase
    {
        private ILookupObjectList _lookupObjectList;
        private IList<ILookupObject> _selectedObjects;
        private IList<ILookupObject> _lookupList;
        private bool _allowNullSelection;
        private bool _allowMultiSelection;
        private bool _bestFitColumns = true;
        private bool _lookupByKey = true;
        private bool _lookupByName;

        public IList<ILookupObject> SelectedObjects
        {
            get { return _selectedObjects; }
        }

        public FrmLookupObject(ILookupObjectList lookupObjectList, IList<ILookupObject> selectedObjects,
            bool allowNullSelection, bool allowMultiSelection, bool lookupByKey, bool lookupByName)
        {
            Debug.Assert(lookupObjectList != null, "LookupObjectList is null. Please load a lookup list!");

            _selectedObjects = selectedObjects;

            _allowMultiSelection = allowMultiSelection;
            _lookupObjectList = lookupObjectList;
            _lookupList = _lookupObjectList.GetLookupList();
            _allowNullSelection = allowNullSelection;
            _lookupByKey = lookupByKey;
            _lookupByName = lookupByName;

            InitializeComponent();
            InitBindings();
            InitControls();
        }

        protected override void InitControls()
        {
            if (_lookupList != null)
            {
                //add dynamic additional value rows
                if (_lookupList.Count > 0)
                {
                    ILookupObject firstLookupObject = _lookupList[0];
                    if (firstLookupObject.LookupAdditionalValues != null)
                    {
                        DynamicGridHelper.AddDynamicColumns(gvLookup, firstLookupObject.LookupAdditionalValues);
                    }
                }
            }

            if (_allowNullSelection)
                btnNullSelection.Visible = true;
            else
                btnNullSelection.Visible = false;

            if (_bestFitColumns)
            {
                gvLookup.BestFitMaxRowCount = 100;
                gvLookup.BestFitColumns();
            }

            if (_lookupByKey && !_lookupByName)
                LookupByKey();
            else if (!_lookupByKey && _lookupByName)
                LookupByName();
            else if (_lookupByKey && _lookupByName)
                LookupByKeyAndName();

            if (_allowMultiSelection)
            {
                colSelected.Visible = true;
                colSelected.VisibleIndex = 0;
            }
        }

        private void SetSelection()
        {
            if (_lookupList != null)
            {
                //set selected object
                if (_selectedObjects != null)
                {
                    if (_selectedObjects.Count == 1 && !_allowMultiSelection)
                    {
                        if (_selectedObjects[0].LookupKey != null)
                        {
                            foreach (ILookupObject lo in _lookupList)
                            {
                                if (String.Equals(_selectedObjects[0].LookupKey.ToString(), lo.LookupKey.ToString()))
                                {
                                    //set focused row
                                    gvLookup.FocusedRowHandle = gvLookup.GetRowHandle(_lookupList.IndexOf(lo));
                                    gvLookup.SelectRow(gvLookup.GetRowHandle(_lookupList.IndexOf(lo)));
                                }
                            }
                        }
                    }
                    else if (_allowMultiSelection)
                    {
                        foreach (var selectedObject in _selectedObjects)
                        {
                            foreach (ILookupObject lo in _lookupList)
                            {
                                if (String.Equals(selectedObject.LookupKey.ToString(), lo.LookupKey.ToString()))
                                {
                                    lo.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void InitBindings()
        {
            Text = "Auswahl: " + _lookupObjectList.LookupListName;
            _objectBindingManager.BindBO(_lookupList, iLookupObjectBindingSource);
        }

        private void AcceptButtonCloseForm()
        {
            GridHelper.EndEditGrid(gcLookup);

            if (_selectedObjects == null) _selectedObjects = new List<ILookupObject>();
            _selectedObjects.Clear();

            if (!_allowMultiSelection)
            {
                if (iLookupObjectBindingSource.Current != null)
                {
                    _selectedObjects.Add((ILookupObject) iLookupObjectBindingSource.Current);
                }
            }
            else
            {
                foreach (var lookupObject in _lookupList)
                {
                    if (lookupObject.Selected)
                    {
                        _selectedObjects.Add(lookupObject);
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonCloseForm()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void gvLookup_DoubleClick(object sender, EventArgs e)
        {
            AcceptButtonCloseForm();
        }

        private void gvLookup_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            ILookupObject lookupObject = _lookupList[e.ListSourceRowIndex];
            DynamicGridHelper.GetUnboundColumnData(e, lookupObject.LookupAdditionalValues);
        }

        private void FrmLookupObject_Shown(object sender, EventArgs e)
        {
            SetSelection();
        }

        public void LookupByKey()
        {
            colLookupKey.SortOrder = ColumnSortOrder.Ascending;
            colLookupKey.OptionsColumn.AllowFocus = true;

            colLookupName.SortOrder = ColumnSortOrder.None;
            colLookupName.OptionsColumn.AllowFocus = true;

            gvLookup.FocusedColumn = colLookupKey;
            if (_lookupList != null)
            {
                if (_lookupList.Count > 0)
                {
                    gvLookup.SelectCell(gvLookup.GetNextVisibleRow(-1), colLookupKey);
                    gvLookup.FocusedRowHandle = gvLookup.GetNextVisibleRow(-1);
                    gvLookup.SelectRow(gvLookup.GetNextVisibleRow(-1));
                }
            }
        }

        public void LookupByName()
        {
            colLookupKey.SortOrder = ColumnSortOrder.None;
            colLookupKey.OptionsColumn.AllowFocus = true;

            colLookupName.SortOrder = ColumnSortOrder.Ascending;
            colLookupName.OptionsColumn.AllowFocus = true;

            gvLookup.FocusedColumn = colLookupName;
            if (_lookupList != null)
            {
                if (_lookupList.Count > 0)
                {
                    gvLookup.SelectCell(gvLookup.GetNextVisibleRow(-1), colLookupName);
                    gvLookup.FocusedRowHandle = gvLookup.GetNextVisibleRow(-1);
                    gvLookup.SelectRow(gvLookup.GetNextVisibleRow(-1));
                }
            }
        }

        public void LookupByKeyAndName()
        {
            colLookupKey.SortOrder = ColumnSortOrder.Ascending;
            colLookupKey.OptionsColumn.AllowFocus = true;

            colLookupName.SortOrder = ColumnSortOrder.None;
            colLookupName.OptionsColumn.AllowFocus = true;

            gvLookup.FocusedColumn = colLookupKey;
            if (_lookupList != null)
            {
                if (_lookupList.Count > 0)
                {
                    gvLookup.SelectCell(gvLookup.GetNextVisibleRow(-1), colLookupKey);
                    gvLookup.FocusedRowHandle = gvLookup.GetNextVisibleRow(-1);
                    gvLookup.SelectRow(gvLookup.GetNextVisibleRow(-1));
                }
            }
        }

        private void btnNullSelection_Click(object sender, EventArgs e)
        {
            if (_allowNullSelection)
            {
                _selectedObjects = new List<ILookupObject>();

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AcceptButtonCloseForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonCloseForm();
        }

        private void repositoryItemCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            GridHelper.EndEditGrid(gcLookup);
        }
    }
}