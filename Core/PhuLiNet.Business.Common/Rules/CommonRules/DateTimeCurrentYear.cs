using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring a DateTime is in the current year.
    /// </summary>
    public class DateTimeCurrentYear : CommonBusinessRule
    {
        private bool _insertValidation;
        private bool _updateValidation;

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="insertValidation">should new records be validated</param>
        /// <param name="updateValidation">should existing records be validated</param>
        public DateTimeCurrentYear(IPropertyInfo primaryProperty, bool insertValidation = true,
            bool updateValidation = true)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            _insertValidation = insertValidation;
            _updateValidation = updateValidation;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            if ((_insertValidation && ((BusinessBase) context.Target).IsNew) // Insert
                || (_updateValidation && !((BusinessBase) context.Target).IsNew)) // Update
            {
                var date = (DateTime?) context.InputPropertyValues[PrimaryProperty];

                if (date.HasValue)
                {
                    if (date.Value.Year != DateTime.Today.Year)
                    {
                        string message = string.Format(ResourcesValidation.DateTimeCurrentYear,
                            PrimaryProperty.FriendlyName);
                        context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                    }
                }
            }
        }
    }
}