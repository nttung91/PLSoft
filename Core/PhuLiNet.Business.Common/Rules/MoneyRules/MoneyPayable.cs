using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Calculation;
using PhuLiNet.Business.Common.Defaults;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Rules.MoneyRules
{
    /// <summary>
    /// Is payable Amount: minimal payable Amount for SFR is 5 Rappen
    /// </summary>
    public class MoneyPayable : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public MoneyPayable(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            object value = context.InputPropertyValues[PrimaryProperty];
            if (value != null)
            {
                Money valueAsMoney = Money.TryConvert(value);
                if (valueAsMoney != null && valueAsMoney.Amount >= 0m &&
                    valueAsMoney.CurrencySymbol.Equals(Organisation.EnterpriseCurrency))
                {
                    if (MoneyRounder.RoundToPayableAmount(valueAsMoney.Amount, 0.05m) != valueAsMoney.Amount)
                    {
                        string message = string.Format(Localization.MoneyRules.MoneyNotPayable,
                            PrimaryProperty.FriendlyName);
                        context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                    }
                }
            }
        }
    }
}