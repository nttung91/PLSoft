using System;
using System.Collections.Generic;
using Csla.Core;
using Csla.Rules;
using Technical.Imaging;
using PhuLiNet.Business.Common.CslaBase;
using PhuLiNet.Business.Common.ImageMgmt;

namespace PhuLiNet.Business.Common.Rules.ImageRules
{
    /// <summary>
    /// Rule ensuring that an image does not exceed the maximum size.
    /// </summary>
    public class MaxImageSize : PhuLiCommonBusinessRule
    {
        public MaxImageSize(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
        }

        protected override void Execute(RuleContext context)
        {
            var target = (IImage) context.Target;

            if (target.Img != null)
            {
                if (target.Img.Length > ImageSizeChecker.MaxSizeInByte)
                {
                    string message = String.Format(Localization.ImageRules.MaxImageSize, PrimaryProperty.FriendlyName,
                        ImageSizeChecker.MaxSize);
                    context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
                }
            }
        }
    }
}