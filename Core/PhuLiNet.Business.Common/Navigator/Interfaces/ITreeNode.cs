using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.Navigator.Interfaces
{
    public interface ITreeNode : ITreeNodeBase, INodeExpandInfo, INodeBrokenRules, INodeLink
    {
        new int ID { get; }
        new int ParentID { get; }
        new string Description { get; }
        new bool InitiallyExpanded { get; }
        new ExtendedBrokenRulesCollection BrokenRules { get; }
        new string BrokenRulesPreview { get; }
        new bool IsValid { get; }
        new object Link { get; }
    }
}