using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring the DateFrom is before the DateTo
    /// (Make sure the DateFrom-Property and the DateTo-Property are connected via Dependency BusinessRule)
    /// </summary>
    public class DateFromToValid : CommonBusinessRule
    {
        private IPropertyInfo DateTo { get; set; }
        private string ErrMsg { get; set; }
        private bool SameDateAllowed { get; set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="dateFrom">Date-From Property to which the rule applies.</param>
        /// <param name="dateTo">Date-To Property to compare with</param>
        /// <param name="errMsg">Error-Message to display (2 Parameters)</param>
        /// <param name="sameDateAllowed">Is Datefrom and DateTo with the same date allowed or not ?</param>
        public DateFromToValid(IPropertyInfo dateFrom, IPropertyInfo dateTo, string errMsg, bool sameDateAllowed = true)
            : base(dateFrom)
        {
            InputProperties = new List<IPropertyInfo> {dateFrom, dateTo};
            DateTo = dateTo;
            ErrMsg = errMsg;
            SameDateAllowed = sameDateAllowed;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var dateFrom = (DateTime?) context.InputPropertyValues[PrimaryProperty];
            var dateTo = (DateTime?) context.InputPropertyValues[DateTo];

            if (dateFrom.HasValue && dateTo.HasValue)
            {
                if ((SameDateAllowed && dateFrom.Value > dateTo.Value) ||
                    (!SameDateAllowed && dateFrom.Value >= dateTo.Value))
                {
                    string message = string.Format(ErrMsg, dateFrom.Value.ToShortDateString(),
                        dateTo.Value.ToShortDateString(), PrimaryProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}