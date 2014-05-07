using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Technical.Utilities.Extensions;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Converts string to upper case letters
    /// </summary>
    public class StringToUpperCase : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringToUpperCase(IPropertyInfo primaryProperty)
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
                    context.AddOutValue(PrimaryProperty, valueAsString.ToUpper());
                }
            }
        }
    }
}