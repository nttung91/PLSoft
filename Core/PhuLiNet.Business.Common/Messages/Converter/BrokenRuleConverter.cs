using System;
using System.Diagnostics;
using Csla.Rules;
using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.Messages.Converter
{
    public static class BrokenRuleConverter
    {
        public static ValidationMessage ConvertToMessage(ExtendedBrokenRule rule)
        {
            Debug.Assert(rule != null, "Rule is null");

            var severity = MessageSeverity.Error;

            if (rule.Severity == RuleSeverity.Error)
            {
                severity = MessageSeverity.Error;
            }
            else if (rule.Severity == RuleSeverity.Warning)
            {
                severity = MessageSeverity.Warning;
            }
            else if (rule.Severity == RuleSeverity.Information)
            {
                severity = MessageSeverity.Information;
            }

            return ValidationMessage.NewValidationMessage(null, null, DateTime.Now, severity, rule.Description, null,
                null);
        }
    }
}