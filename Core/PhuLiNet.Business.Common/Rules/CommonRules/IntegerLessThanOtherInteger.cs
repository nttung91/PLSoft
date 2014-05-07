using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    public class IntegerLessThanOtherInteger : CommonBusinessRule
    {
        public IPropertyInfo IntSecondProperty { get; private set; }

        public IntegerLessThanOtherInteger(IPropertyInfo intFirst, IPropertyInfo intSecond)
            : base(intFirst)
        {
            InputProperties = new List<IPropertyInfo> {intFirst, intSecond};

            IntSecondProperty = intSecond;
            AffectedProperties.Add(intSecond);
        }

        protected override void Execute(RuleContext context)
        {
            var intFirst = (int?) context.InputPropertyValues[PrimaryProperty];
            var intSecond = (int?) context.InputPropertyValues[IntSecondProperty];

            if (intFirst != null && intSecond != null)
            {
                if (intFirst > intSecond)
                {
                    var message = string.Format(ResourcesValidation.IntegerLessThanOtherInteger,
                        PrimaryProperty.FriendlyName, IntSecondProperty.FriendlyName);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}