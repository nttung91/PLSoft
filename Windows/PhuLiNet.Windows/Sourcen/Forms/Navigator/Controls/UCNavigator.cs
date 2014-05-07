using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Csla.Rules;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using PhuLiNet.Business.Common.Navigator;
using PhuLiNet.Business.Common.Navigator.Interfaces;
using PhuLiNet.Business.Common.Rules;
using Windows.Core.Controls;
using Windows.Core.Forms.Navigator.NodeEventArgs;
using Windows.Core.Forms.Navigator.Operations;
using TreeNode = PhuLiNet.Business.Common.Navigator.TreeNode;

namespace Windows.Core.Forms.Navigator.Controls
{
    [ToolboxItem(true)]
    public partial class UCNavigator : UCBusinessControlBase
    {
        public UCNavigator()
        {
            InitializeComponent();
            BusinessObjectTreeBuilder = new TreeBuilder();
        }

        public delegate void TreeNodeClicked(object sender, NavigatorNodeClickEventArgs e);

        public event TreeNodeClicked OnTreeNodeClicked;

        protected void DoTreeNodeClicked(object sender, NavigatorNodeClickEventArgs e)
        {
            if (OnTreeNodeClicked != null)
                OnTreeNodeClicked(sender, e);
        }

        public TreeBuilder BusinessObjectTreeBuilder { get; private set; }

        public Dictionary<Type, Bitmap> TreeNodeIconDictionary { set; private get; }

        public void BuildTree<T>(IBuildBusinessObjectTree<T> builder, T businessObject)
        {
            tlObjectTree.BeginInit();
            _objectBindingManager.ClearBindings(bsObjectTree, false);
            ClearTree();
            builder.BuildBusinessObjectTree(BusinessObjectTreeBuilder, businessObject);
            ShowTree();
            tlObjectTree.EndInit();
        }

        public void ShowTree()
        {
            InitBindings();
            SetIcons();
            DefaultExpandNodes();
        }

        public void DefaultExpandNodes()
        {
            var newExpandDefinedNodesOperation = new ExpandNodesOperation();
            tlObjectTree.NodesIterator.DoOperation(newExpandDefinedNodesOperation);
            newExpandDefinedNodesOperation.Execute(tlObjectTree.Nodes.FirstNode);
        }

        private void SetIcons()
        {
            var newIconSetOperation = new IconSetOperation(tlObjectTree, TreeNodeIconDictionary);
            tlObjectTree.NodesIterator.DoOperation(newIconSetOperation);
            newIconSetOperation.Execute(tlObjectTree.Nodes.FirstNode);
        }

        protected override void InitBindings()
        {
            _objectBindingManager.BindBO(BusinessObjectTreeBuilder.BusinessObjectTree, bsObjectTree);
            _objectBindingManager.RestoreBindings(bsObjectTree, true);
        }

        public void ClearTree()
        {
            BusinessObjectTreeBuilder.BusinessObjectTree.ClearTree();
        }

        private void bbiExpandAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            tlObjectTree.ExpandAll();
        }

        private void tcNavigator_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl is TreeList)
            {
                var tree = (TreeList) e.SelectedControl;
                TreeListHitInfo hit = tree.CalcHitInfo(e.ControlMousePosition);
                if (hit.HitInfoType == HitInfoType.Cell)
                {
                    object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);

                    e.Info = new ToolTipControlInfo(cellInfo,
                        "Ein Mausklick in den Fehlertext bringt Sie zum Feld mit diesem Fehler.");
                }
            }
        }

        private void bbiStandard_ItemClick(object sender, ItemClickEventArgs e)
        {
            DefaultExpandNodes();
        }

        private void tlObjectTree_MouseClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hInfo = (sender as TreeList).CalcHitInfo(new Point(e.X, e.Y));
            if (hInfo.Node != null)
            {
                object treeNode = tlObjectTree.GetDataRecordByNode(hInfo.Node);
                if (treeNode != null && treeNode is ITreeNode)
                {
                    DoTreeNodeClicked(this,
                        new NavigatorNodeClickEventArgs((ITreeNode) treeNode,
                            BusinessObjectTreeBuilder.BusinessObjectTree));
                }
            }
        }

        private void tlObjectTree_CustomDrawNodePreview(object sender, CustomDrawNodePreviewEventArgs e)
        {
            Rectangle bounds = e.Bounds;
            bounds.Offset(15, 0);
            bounds.Width -= 15;
            TreeListNode node = e.Node;

            Color foreColor;

            if (HasNodeErrors(node))
                foreColor = Color.Red;
            else
                foreColor = Color.Magenta;

            e.Appearance.ForeColor = foreColor;
            e.Graphics.FillRectangle(new SolidBrush(e.Appearance.BackColor), e.Bounds);
            var sf = new StringFormat(e.Appearance.GetStringFormat());
            sf.FormatFlags ^= StringFormatFlags.NoWrap;
            e.Appearance.DrawString(e.Cache, e.PreviewText, bounds, sf);
            e.Handled = true;
        }

        private static bool HasNodeErrors(TreeListNode node)
        {
            bool result = false;
            if (node != null)
            {
                object treeNode = node.TreeList.GetDataRecordByNode(node);
                if (treeNode is TreeNode)
                {
                    ExtendedBrokenRulesCollection brokenRules = ((TreeNode) treeNode).BrokenRules;
                    foreach (var item in brokenRules)
                    {
                        if (item.Severity == RuleSeverity.Error)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private void SolidBrush(Color color)
        {
            throw new NotImplementedException();
        }
    }
}