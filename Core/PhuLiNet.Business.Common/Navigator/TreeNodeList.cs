using Csla.Core;
using PhuLiNet.Business.Common.Navigator.Interfaces;

namespace PhuLiNet.Business.Common.Navigator
{
    public class TreeNodeList : ReadOnlyBindingList<ITreeNode>, ITreeNodeList
    {
        public new void Add(ITreeNode item)
        {
            IsReadOnly = false;
            base.Add(item);
            IsReadOnly = true;
        }

        public void ClearTree()
        {
            IsReadOnly = false;
            base.Clear();
            IsReadOnly = true;
        }

        public ITreeNode FindTreeNode(int id)
        {
            ITreeNode result = null;
            foreach (var item in this)
            {
                if (item.ID == id)
                    result = item;
            }
            return result;
        }
    }
}