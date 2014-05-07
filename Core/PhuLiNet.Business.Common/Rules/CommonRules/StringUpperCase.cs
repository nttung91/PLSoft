using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Technical.Utilities.Extensions;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a string has only upper case characters.
    /// </summary>
    public class StringUpperCase : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringUpperCase(IPropertyInfo primaryProperty)
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
            var valueAsString = (string) context.InputPropertyValues[PrimaryProperty];

            if (valueAsString != null && valueAsString.IsNotEmpty())
            {
                if (!valueAsString.IsUpper())
                {
                    string message = string.Format(ResourcesValidation.StringUpperCase, PrimaryProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}