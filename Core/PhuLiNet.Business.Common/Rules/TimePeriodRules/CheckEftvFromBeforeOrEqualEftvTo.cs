using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.TimePeriodRules
{
    public class CheckEftvFromBeforeOrEqualEftvTo : CommonBusinessRule
    {
        public CheckEftvFromBeforeOrEqualEftvTo()
        {
        }

        public CheckEftvFromBeforeOrEqualEftvTo(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var target = (ITimePeriod) context.Target;

            if (target.EftvFrom.HasValue && target.EftvTo.HasValue)
            {
                if (target.EftvFrom.Value.Date > target.EftvTo.Value.Date)
                {
                    string message = string.Format(FromToDate.DateToIsBeforeFrom, target.EftvFrom.Value.Date,
                        target.EftvTo.Value.Date);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}