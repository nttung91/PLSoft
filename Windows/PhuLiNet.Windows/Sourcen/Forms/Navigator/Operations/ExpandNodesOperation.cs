using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using PhuLiNet.Business.Common.Navigator.Interfaces;

namespace Windows.Core.Forms.Navigator.Operations
{
    public class ExpandNodesOperation : TreeListOperation
    {
        public ExpandNodesOperation()
        {
        }

        public override void Execute(TreeListNode node)
        {
            if (node == null) return;


            object treeNode = node.TreeList.GetDataRecordByNode(node);
            var expandInfo = treeNode as INodeExpandInfo;
            bool expanded = expandInfo != null && expandInfo.InitiallyExpanded;

            if (node.Expanded != expanded)
            {
                node.Expanded = expanded;
            }

            if (hasBrolenRulesPreviewValue(treeNode))
            {
                node.TreeList.FocusedNode = node;
                node.Expanded = true;
            }
        }

        private static bool hasBrolenRulesPreviewValue(object treeNode)
        {
            bool result = false;
            if (treeNode is INodeBrokenRules)
            {
                var brolenRules = treeNode as INodeBrokenRules;
                if (!string.IsNullOrEmpty(brolenRules.BrokenRulesPreview))
                    result = true;
            }
            return result;
        }

        public override bool NeedsFullIteration
        {
            get { return true; }
        }
    }
}