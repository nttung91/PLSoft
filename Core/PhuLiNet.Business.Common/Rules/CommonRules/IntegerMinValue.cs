using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a Integer has a minimum value of x.
    /// </summary>
    public class IntegerMinValue : CommonBusinessRule
    {
        public int CompareValue { get; private set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public IntegerMinValue(IPropertyInfo primaryProperty, int compareValue)
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
            var value = context.InputPropertyValues[PrimaryProperty];
            if (value != null)
            {
                int valueAsInteger = Convert.ToInt32(value);

                if (valueAsInteger < CompareValue)
                {
                    string message = string.Format(ResourcesValidation.IntegerMinValue, CompareValue.ToString());
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}