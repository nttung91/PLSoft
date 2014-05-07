namespace PhuLiNet.Business.Common.Navigator.Interfaces
{
    public interface ITreeNodeList
    {
        void Add(ITreeNode item);
        void ClearTree();
        ITreeNode FindTreeNode(int id);
    }
}