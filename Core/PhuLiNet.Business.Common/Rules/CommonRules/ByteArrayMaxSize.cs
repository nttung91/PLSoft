using System;
using System.Collections.Generic;
using System.Globalization;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a byte array is not greater than x bytes.
    /// </summary>
    public class ByteArrayMaxSize : CommonBusinessRule
    {
        /// <summary>
        /// Max byte size.
        /// </summary>
        public int MaxBytes { get; private set; }

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="maxBytes"></param>
        public ByteArrayMaxSize(IPropertyInfo primaryProperty, int maxBytes)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            MaxBytes = maxBytes;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            object value = context.InputPropertyValues[PrimaryProperty];
            if (value != null)
            {
                var valueAsByte = (byte[]) value;

                if (valueAsByte.Length > MaxBytes)
                {
                    int maxKilobytes = MaxBytes/1024;
                    string outValue = maxKilobytes.ToString(CultureInfo.InvariantCulture);
                    string message = String.Format(ResourcesValidation.ByteArrayMaxSize, PrimaryProperty.FriendlyName,
                        outValue);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}