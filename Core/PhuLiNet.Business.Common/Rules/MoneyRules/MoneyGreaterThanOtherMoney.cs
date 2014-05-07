using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Rules.MoneyRules
{
    public class MoneyGreaterThanOtherMoney : CommonBusinessRule
    {
        public IPropertyInfo MoneySecondProperty { get; private set; }

        public MoneyGreaterThanOtherMoney(IPropertyInfo moneyFirst, IPropertyInfo moneySecond)
            : base(moneyFirst)
        {
            InputProperties = new List<IPropertyInfo> {moneyFirst, moneySecond};

            MoneySecondProperty = moneySecond;
            AffectedProperties.Add(moneySecond);
        }

        protected override void Execute(RuleContext context)
        {
            var moneyFirst = context.InputPropertyValues[PrimaryProperty] as Money;
            var moneySecond = context.InputPropertyValues[MoneySecondProperty] as Money;

            if (moneyFirst != null && moneySecond != null)
            {
                if (moneyFirst <= moneySecond)
                {
                    string message = string.Format(Localization.MoneyRules.MoneyGreaterThanOtherMoney,
                        PrimaryProperty.FriendlyName, MoneySecondProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}