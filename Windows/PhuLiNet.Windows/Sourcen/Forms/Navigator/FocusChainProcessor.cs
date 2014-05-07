using PhuLiNet.Business.Common.Navigator.Interfaces;
using Windows.Core.Forms.Navigator.Interfaces;

namespace Windows.Core.Forms.Navigator
{
    public class FocusChainProcessor
    {
        private ITreeNodeList _tree;
        private ISetFocusOnBusinessObject _focusSetter;

        public FocusChainProcessor(ITreeNodeList tree, ISetFocusOnBusinessObject focusSetter)
        {
            _tree = tree;
            _focusSetter = focusSetter;
        }

        public void processFocusChain(ITreeNode treeNode)
        {
            if (treeNode == null) return;

            if (treeNode.ParentID == 0)
            {
                FocusBusinessObject(treeNode.Link);
            }
            else
            {
                processFocusChain(_tree.FindTreeNode(treeNode.ParentID));
                FocusBusinessObject(treeNode.Link);
            }
        }

        private void FocusBusinessObject(object businesObject)
        {
            if (businesObject == null || _focusSetter == null) return;

            _focusSetter.SetFocusOnBusinessObject(businesObject);
        }
    }
}