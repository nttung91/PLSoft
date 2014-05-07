using Csla.Rules;

namespace PhuLiNet.Business.Common.Rules
{
    public interface IBrokenBusinessRules
    {
        BrokenRulesTree GetAllBrokenRules();
    }
}