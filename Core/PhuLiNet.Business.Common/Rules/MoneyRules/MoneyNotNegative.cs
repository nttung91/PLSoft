﻿using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Unit;

namespace PhuLiNet.Business.Common.Rules.MoneyRules
{
    /// <summary>
    /// Rule ensuring that a money instance is not negative.
    /// </summary>
    public class MoneyNotNegative : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public MoneyNotNegative(IPropertyInfo primaryProperty)
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
                if (valueAsMoney != null && valueAsMoney.Amount < 0m)
                {
                    string message = string.Format(Localization.MoneyRules.MoneyNotNegative,
                        PrimaryProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}