namespace PhuLiNet.Business.Common.Rules
{
    public interface IBrokenRulesCollector
    {
        ExtendedBrokenRulesCollection BrokenRules { get; }
        void Collect();
    }
}