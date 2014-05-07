using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a string has not to much lines.
    /// </summary>
    public class StringMaxLines : CommonBusinessRule
    {
        /// <summary>
        /// Max number of lines.
        /// </summary>
        public int MaxLines { get; private set; }

        public IPropertyInfo MaxLinesProperty { get; set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringMaxLines(IPropertyInfo primaryProperty, int maxLines)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            MaxLines = maxLines;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringMaxLines(IPropertyInfo primaryProperty, IPropertyInfo maxLinesProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty, maxLinesProperty};
            MaxLinesProperty = maxLinesProperty;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var value = (string) context.InputPropertyValues[PrimaryProperty];

            if (MaxLinesProperty != null)
            {
                MaxLines = (int) context.InputPropertyValues[MaxLinesProperty];
            }

            if (value != null)
            {
                string[] valueArray = value.Split(new string[1] {Environment.NewLine}, StringSplitOptions.None);

                if (!String.IsNullOrEmpty(value) && (valueArray != null) && (valueArray.Length > MaxLines))
                {
                    string message = String.Format(ResourcesValidation.StringMaxLines, PrimaryProperty.FriendlyName,
                        MaxLines.ToString());
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}