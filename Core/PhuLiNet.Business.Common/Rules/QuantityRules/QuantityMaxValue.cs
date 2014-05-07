using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Rules.QuantityRules
{
    /// <summary>
    /// Rule ensuring that a quantity has a maximum value of x.
    /// </summary>
    public class QuantityMaxValue : CommonBusinessRule
    {
        public decimal CompareValue { get; private set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public QuantityMaxValue(IPropertyInfo primaryProperty, decimal compareValue)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            CompareValue = compareValue;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var qty = context.InputPropertyValues[PrimaryProperty] as Quantity;

            if (qty != null)
            {
                if (qty.Value > CompareValue)
                {
                    string message = string.Format(Localization.QuantityRules.QuantityMaxValue, CompareValue.ToString());
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}