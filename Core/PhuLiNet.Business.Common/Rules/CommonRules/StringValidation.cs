using System.Collections.Generic;
using System.Linq;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Technical.Utilities.Extensions;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that string is in the list of valiedStrings
    /// </summary>
    public class StringValidation : CommonBusinessRule
    {
        private string[] _validStrings;

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringValidation(IPropertyInfo primaryProperty, string[] validStrings)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            _validStrings = validStrings;
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
                if (!_validStrings.Contains<string>(valueAsString))
                {
                    string message = string.Format(ResourcesValidation.StringValidation, valueAsString);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}