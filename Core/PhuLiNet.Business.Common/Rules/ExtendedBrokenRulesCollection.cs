using System;
using Csla.Core;
using Csla.Rules;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.Rules
{
    /// <summary>
    /// Extends the broken rules collection class from CSLA
    /// </summary>
    public class ExtendedBrokenRulesCollection : ReadOnlyBindingList<ExtendedBrokenRule>,
        IDuplicateBusiness<ExtendedBrokenRulesCollection>
    {
        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Error.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountError
        {
            get { return GetNumberOfBrokenRules(RuleSeverity.Error); }
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Warning.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountWarning
        {
            get { return GetNumberOfBrokenRules(RuleSeverity.Warning); }
        }

        /// <summary>
        /// Gets the number of broken rules in
        /// the collection that have a severity
        /// of Information.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountInformation
        {
            get { return GetNumberOfBrokenRules(RuleSeverity.Information); }
        }

        private int GetNumberOfBrokenRules(RuleSeverity severity)
        {
            int count = 0;

            foreach (var item in this)
            {
                if (item.Severity == severity) count++;
            }

            return count;
        }

        public void SetReadOnly(bool readOnly)
        {
            IsReadOnly = readOnly;
        }

        public void Add(BrokenRule rule, object link)
        {
            IsReadOnly = false;
            var item = new ExtendedBrokenRule(rule, link);
            Add(item);
            IsReadOnly = true;
        }

        public void ClearBrokenRules()
        {
            IsReadOnly = false;
            Clear();
            IsReadOnly = true;
        }

        public override string ToString()
        {
            string brokenRulesAsString = string.Empty;

            foreach (ExtendedBrokenRule rule in this)
            {
                brokenRulesAsString = rule + Environment.NewLine;
            }

            return brokenRulesAsString;
        }

        #region IDuplicateBusiness<ExtendedBrokenRulesCollection> Members

        public ExtendedBrokenRulesCollection Duplicate()
        {
            var clone = new ExtendedBrokenRulesCollection();
            clone.IsReadOnly = false;

            foreach (ExtendedBrokenRule rule in this)
            {
                clone.Add(rule.Duplicate());
            }

            clone.IsReadOnly = true;
            return clone;
        }

        #endregion
    }
}