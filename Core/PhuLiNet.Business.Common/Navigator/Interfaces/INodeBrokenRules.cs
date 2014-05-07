using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.Navigator.Interfaces
{
    public interface INodeBrokenRules
    {
        ExtendedBrokenRulesCollection BrokenRules { get; }
        string BrokenRulesPreview { get; }
        bool IsValid { get; }
    }
}