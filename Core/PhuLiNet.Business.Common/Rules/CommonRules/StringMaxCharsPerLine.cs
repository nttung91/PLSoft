using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a string has not to long lines.
    /// </summary>
    public class StringMaxCharsPerLine : CommonBusinessRule
    {
        /// <summary>
        /// Max length of lines.
        /// </summary>
        public int MaxCharsPerLine { get; private set; }

        public IPropertyInfo MaxCharsPerLineProperty { get; set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringMaxCharsPerLine(IPropertyInfo primaryProperty, int maxCharsPerLine)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            MaxCharsPerLine = maxCharsPerLine;
        }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public StringMaxCharsPerLine(IPropertyInfo primaryProperty, IPropertyInfo maxCharsPerLineProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty, maxCharsPerLineProperty};
            MaxCharsPerLineProperty = maxCharsPerLineProperty;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var value = (string) context.InputPropertyValues[PrimaryProperty];

            if (MaxCharsPerLineProperty != null)
            {
                MaxCharsPerLine = (int) context.InputPropertyValues[MaxCharsPerLineProperty];
            }

            if (value != null)
            {
                string[] valueArray = value.Split(new string[1] {Environment.NewLine}, StringSplitOptions.None);

                bool maxExceeded = false;
                if (valueArray != null)
                {
                    foreach (string line in valueArray)
                    {
                        if (line.Length > MaxCharsPerLine)
                        {
                            maxExceeded = true;
                            break;
                        }
                    }
                }

                if (!String.IsNullOrEmpty(value) && (maxExceeded))
                {
                    string message = string.Format(ResourcesValidation.StringMaxCharsPerLine,
                        PrimaryProperty.FriendlyName, MaxCharsPerLine.ToString());
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}