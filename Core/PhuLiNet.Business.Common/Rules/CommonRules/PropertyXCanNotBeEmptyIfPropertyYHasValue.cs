using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule to prevent the case when one property has value and the other one doesn't.
    /// </summary>
    /// <remarks>Apply for <see cref="string"/> properties only.</remarks>
    public class PropertyXCanNotBeEmptyIfPropertyYHasValue : CommonBusinessRule
    {
        private IPropertyInfo DependentProperty { get; set; }

        public PropertyXCanNotBeEmptyIfPropertyYHasValue()
        {
        }

        public PropertyXCanNotBeEmptyIfPropertyYHasValue(IPropertyInfo primaryProperty, IPropertyInfo dependentProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty, dependentProperty};
            DependentProperty = dependentProperty;
            MessageText = ResourcesValidation.PropertyXCantBeEmptyIfPropertyYHasValue;
        }

        protected override void Execute(RuleContext context)
        {
            var primaryValue = context.InputPropertyValues[PrimaryProperty] + string.Empty;
            var dependentValue = context.InputPropertyValues[DependentProperty] + string.Empty;
            if (!string.IsNullOrWhiteSpace(dependentValue) && string.IsNullOrWhiteSpace(primaryValue))
            {
                context.AddErrorResult(string.Format(MessageText,
                    PrimaryProperty.FriendlyName, DependentProperty.FriendlyName));
            }
        }
    }
}