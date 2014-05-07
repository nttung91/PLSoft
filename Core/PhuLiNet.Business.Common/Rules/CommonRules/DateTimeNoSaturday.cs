using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring a DateTime is not a saturday.
    /// </summary>
    public class DateTimeNoSaturday : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public DateTimeNoSaturday(IPropertyInfo primaryProperty)
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
            var date = (DateTime?) context.InputPropertyValues[PrimaryProperty];

            if (date.HasValue)
            {
                if (date.Value.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    string message = string.Format(ResourcesValidation.DateTimeNoSaturday,
                        date.Value.ToShortDateString(), PrimaryProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}