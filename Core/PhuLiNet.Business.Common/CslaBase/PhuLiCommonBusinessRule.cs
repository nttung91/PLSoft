using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace PhuLiNet.Business.Common.CslaBase
{
    public abstract class PhuLiCommonBusinessRule : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Primary property.</param>
        protected PhuLiCommonBusinessRule(IPropertyInfo primaryProperty) : base(primaryProperty)
        {
            Severity = RuleSeverity.Error;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        protected PhuLiCommonBusinessRule()
        {
            Severity = RuleSeverity.Error;
        }
    }
}