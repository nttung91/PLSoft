namespace PhuLiNet.Business.Common.Navigator.Interfaces
{
    public interface IBuildBusinessObjectTree<T>
    {
        void BuildBusinessObjectTree(TreeBuilder treeBuilder, T businessObject);
    }
}