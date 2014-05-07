using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using Technical.Imaging.Validation;
using PhuLiNet.Business.Common.ImageMgmt;

namespace PhuLiNet.Business.Common.Rules.ImageRules
{
    /// <summary>
    /// Rule ensuring that a byte array is a valid image.
    /// </summary>
    public class ByteArrayIsImage : CommonBusinessRule
    {
        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        public ByteArrayIsImage(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var target = (IImage) context.Target;

            if (target.Img != null)
            {
                if (!ImageValidator.GetInstance().IsValidImage(target.Img))
                {
                    string message = Localization.ImageRules.UnkownImageFormat;
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}