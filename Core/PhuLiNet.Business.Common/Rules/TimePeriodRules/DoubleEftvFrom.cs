using System.Collections.Generic;
using System.Diagnostics;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.TimePeriodRules
{
    public class DoubleEftvFrom : CommonBusinessRule
    {
        public DoubleEftvFrom(IPropertyInfo primaryProperty)
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

            if (target.EftvFrom.HasValue)
            {
                var parent = target as ITimePeriodList;
                int count = 0;
                if (parent != null)
                {
                    List<ITimePeriod> list = parent.TimePeriodList;
                    ;
                    if (list != null && list.Count > 1)
                    {
                        foreach (ITimePeriod item in list)
                        {
                            ITimePeriod fromTo = item;
                            if (fromTo != null)
                            {
                                if (fromTo.EftvFrom == target.EftvFrom)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Debug.Assert(false, "ITimePeriodList is not implemented");
                }
                if (count > 1)
                {
                    string message = FromToDate.FromDateAlreadyExists;
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}