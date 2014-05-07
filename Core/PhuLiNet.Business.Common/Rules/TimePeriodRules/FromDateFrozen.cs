using System;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Technical.Utilities.Helpers;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.TimePeriodRules
{
    public class FromDateFrozen : CommonBusinessRule
    {
        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var target = (IEftvFromChange) context.Target;

            DateTime? from = target.EftvFrom;
            DateTime? fromOriginal = target.EftvFromOriginal;
            if (AssignmentHelper.AssignNullableValue(ref from, fromOriginal))
            {
                if (target.IsNew == false)
                {
                    string message = FromToDate.FromDateFrozen;
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}