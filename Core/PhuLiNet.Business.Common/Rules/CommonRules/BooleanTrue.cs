using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a Boolean has the value true.
    /// </summary>
    public class BooleanTrue : CommonBusinessRule
    {
        /// <summary>
        /// Message the rule shows.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public BooleanTrue(IPropertyInfo primaryProperty, string message)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            Message = message;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var valueAsBool = (bool) context.InputPropertyValues[PrimaryProperty];

            if (valueAsBool != true)
            {
                //Description (die Fehlerbeschreibung) muss von aussen über RuleArgs gesetzt werden.
                if (Message == null)
                {
                    Message = "The bool [" + PrimaryProperty.FriendlyName + "] must be true";
                }

                context.Results.Add(new RuleResult(RuleName, PrimaryProperty, Message) {Severity = Severity});
            }
        }
    }
}