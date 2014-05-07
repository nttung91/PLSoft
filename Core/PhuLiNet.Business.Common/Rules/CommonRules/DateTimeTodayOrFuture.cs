using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring a DateTime is today or in the future.
    /// </summary>
    public class DateTimeTodayOrFuture : CommonBusinessRule
    {
        private readonly bool _insertValidation;
        private readonly bool _updateValidation;
        private readonly bool _validateUnchangedObject;

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        public DateTimeTodayOrFuture(IPropertyInfo primaryProperty, bool insertValidation = true,
            bool updateValidation = true, bool validateUnchangedObject = true)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            _insertValidation = insertValidation;
            _updateValidation = updateValidation;
            _validateUnchangedObject = validateUnchangedObject;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            if ((_insertValidation && ((ITrackStatus) context.Target).IsNew) || // Insert
                (_updateValidation && !((ITrackStatus) context.Target).IsNew && ((ITrackStatus) context.Target).IsDirty) ||
                // Update
                (_validateUnchangedObject && !((ITrackStatus) context.Target).IsNew))
                // Validate loaded but unchanged objects too
            {
                var date = (DateTime?) context.InputPropertyValues[PrimaryProperty];

                if (date.HasValue)
                {
                    if (date.Value < DateTime.Today)
                    {
                        string message = string.Format(ResourcesValidation.DateTimeTodayOrFuture,
                            date.Value.ToShortDateString(), PrimaryProperty.FriendlyName);
                        context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                    }
                }
            }
        }
    }
}