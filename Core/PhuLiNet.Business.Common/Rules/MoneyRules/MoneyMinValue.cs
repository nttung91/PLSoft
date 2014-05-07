using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Rules.MoneyRules
{
    /// <summary>
    /// Rule ensuring that a money has a minimum value of x.
    /// </summary>
    public class MoneyMinValue : CommonBusinessRule
    {
        public decimal CompareValue { get; private set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public MoneyMinValue(IPropertyInfo primaryProperty, decimal compareValue)
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
            var moneyFirst = context.InputPropertyValues[PrimaryProperty] as Money;

            if (moneyFirst != null)
            {
                if (moneyFirst.Amount < CompareValue)
                {
                    string message = string.Format(Localization.MoneyRules.MoneyMinValue, CompareValue.ToString());
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}