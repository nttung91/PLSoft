using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PhuLiNet.Business.Common.CslaBase;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;

namespace Windows.Core.Controls.Adapters
{
    public class TreeListAdapter : ListControlAdapter
    {
        private readonly TreeList _treeList;

        public TreeListAdapter(TreeList treeList)
        {
            _treeList = treeList;
            BestFitVisibleOnly = true;
            _treeList.KeyDown += OnKeyDown;
            _treeList.FocusedNodeChanged += FocusedNodeChanged;
            _treeList.BeforeFocusNode += TreeListOnBeforeFocusNode;
        }

        private void TreeListOnBeforeFocusNode(object sender, BeforeFocusNodeEventArgs beforeFocusNodeEventArgs)
        {
            if (!beforeFocusNodeEventArgs.CanFocus) return;
            beforeFocusNodeEventArgs.CanFocus = OnItemChanging(sender,
                _treeList.GetDataRecordByNode(beforeFocusNodeEventArgs.Node));
        }

        public override bool AllowMultiSelection
        {
            get { return _treeList.OptionsSelection.MultiSelect; }
            set { _treeList.OptionsSelection.MultiSelect = value; }
        }

        public bool BestFitVisibleOnly
        {
            get { return _treeList.BestFitVisibleOnly; }
            set { _treeList.BestFitVisibleOnly = value; }
        }

        public override bool ShowAutoFilterRow
        {
            get { return _treeList.OptionsView.ShowAutoFilterRow; }
            set { _treeList.OptionsView.ShowAutoFilterRow = value; }
        }

        public override string Name
        {
            get { return _treeList.Name; }
        }

        public override bool Editable
        {
            get { return _treeList.OptionsBehavior.Editable; }
            set { _treeList.OptionsBehavior.Editable = value; }
        }

        public override void SaveLayoutToStream(Stream stream)
        {
            _treeList.SaveLayoutToStream(stream);
        }

        public override void RestoreLayoutFromStream(Stream stream)
        {
            _treeList.RestoreLayoutFromStream(stream);
        }

        public override void BestFitColumns()
        {
            _treeList.BestFitColumns();
        }

        public override void CancelEdit()
        {
            _treeList.HideEditor();
        }

        public override void CommitEdit()
        {
            _treeList.CloseEditor();
        }

        public override void RefreshData()
        {
            _treeList.RefreshDataSource();
        }

        public override void AddRow()
        {
            // What to do here? We can't implement this here
        }

        public override IEnumerable<IPhuLiBusinessBase> GetSelectedRows()
        {
            var nodes = _treeList.Selection;
            foreach (var node in nodes.Cast<TreeListNode>().OrderByDescending(p => p.Level))
            {
                var item = _treeList.GetDataRecordByNode(node) as IPhuLiBusinessBase;
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        private void FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs focusedNodeChangedEventArgs)
        {
            if (focusedNodeChangedEventArgs.Node != null)
            {
                OnElementUpdated(sender, _treeList.GetDataRecordByNode(focusedNodeChangedEventArgs.Node));
            }
        }

        public override void ForceLeaveFocus()
        {
            CommitEdit();
            _treeList.EndCurrentEdit();
        }

        public override void Print()
        {
            GridPrint.PrintComponent(_treeList, true);
        }

        public override void Export(ExportType exportType)
        {
            GridExport.ExportComponent(_treeList, exportType);
        }
    }
}