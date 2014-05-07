using System;
using PhuLiNet.Business.Common.Navigator.Interfaces;

namespace Windows.Core.Forms.Navigator.NodeEventArgs
{
    public class NavigatorNodeClickEventArgs : EventArgs
    {
        public NavigatorNodeClickEventArgs(ITreeNode clickedNode, ITreeNodeList treeList)
        {
            ClickedNode = clickedNode;
            TreeList = treeList;
        }

        public ITreeNode ClickedNode { get; set; }
        public ITreeNodeList TreeList { get; set; }
    }
}