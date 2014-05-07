using System.Collections.Generic;
using System.Text.RegularExpressions;
using Csla.Core;
using Csla.Rules;
using Csla.Rules.CommonRules;
using PhuLiNet.Business.Common.Localization;

namespace PhuLiNet.Business.Common.Rules.CommonRules
{
    /// <summary>
    /// Rule ensuring that a string don't contains some specific characters.
    /// </summary>
    public class StringNotCotaingingInvalidCharacters : CommonBusinessRule
    {
        private readonly Regex _regex;
        private readonly string _prohibitedCharacters;

        /// <summary>
        /// Creates an instance of the rule.
        /// </summary>
        /// <param name="primaryProperty">Property to which the rule applies.</param>
        /// <param name="prohibitedCharacters">prohibited characters</param>
        public StringNotCotaingingInvalidCharacters(IPropertyInfo primaryProperty, string prohibitedCharacters)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};
            _prohibitedCharacters = prohibitedCharacters;
            _regex = CreateRegex(prohibitedCharacters);
            MessageText = ResourcesValidation.StringContainsInvalidCharacters;
        }

        /// <summary>
        /// Rule implementation.
        /// </summary>
        /// <param name="context">Rule context.</param>
        protected override void Execute(RuleContext context)
        {
            var valueAsString = context.InputPropertyValues[PrimaryProperty] as string;

            if (IsValid(valueAsString, _regex))
                return;

            var message = string.Format(MessageText, PrimaryProperty.FriendlyName,
                string.Join(" ", _prohibitedCharacters.ToCharArray()));
            context.Results.Add(new RuleResult(RuleName, PrimaryProperty, message) {Severity = Severity});
        }

        public static bool IsValid(string stringToCheck, string prohibitedCharacters)
        {
            return IsValid(stringToCheck, CreateRegex(prohibitedCharacters));
        }

        private static bool IsValid(string stringToCheck, Regex regex)
        {
            return string.IsNullOrEmpty(stringToCheck) || !regex.IsMatch(stringToCheck);
        }

        private static Regex CreateRegex(string prohibitedCharacters)
        {
            return new Regex(string.Format(@"[{0}]", prohibitedCharacters.Replace(@"\", @"\\")));
        }
    }
}