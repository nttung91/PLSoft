using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring a DateTime is in the future for Number of Days.
    /// </summary>
    public class DateTimeFutureNumOfDays : CommonBusinessRule
    {
        private readonly int _numOfDays;
        private readonly bool _insertValidation;
        private readonly bool _updateValidation;
        private readonly bool _validateUnchangedObject;

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="numOfDays">Number of daysin the future (not allowed)</param>
        /// <param name="insertValidation">should new records be validated</param>
        /// <param name="updateValidation">should existing records be validated</param>
        /// <param name="validateUnchangedObject">should unchanged records be validated</param>
        public DateTimeFutureNumOfDays(IPropertyInfo primaryProperty, int numOfDays, bool insertValidation = true,
            bool updateValidation = true, bool validateUnchangedObject = true)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            _numOfDays = numOfDays;
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
                    if (date.Value <= DateTime.Today.AddDays(_numOfDays))
                    {
                        string message = string.Format(ResourcesValidation.DateTimeFutureNumOfDays,
                            PrimaryProperty.FriendlyName, _numOfDays);
                        context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                    }
                }
            }
        }
    }
}