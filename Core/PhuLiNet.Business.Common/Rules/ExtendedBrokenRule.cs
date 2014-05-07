using Csla.Rules;
using PhuLiNet.Business.Common.Interfaces;

namespace PhuLiNet.Business.Common.Rules
{
    /// <summary>
    /// Extends the broken rules class from CSLA
    /// Provides a link to the object which owns the broken rule
    /// </summary>
    public class ExtendedBrokenRule : IDuplicateBusiness<ExtendedBrokenRule>
    {
        private string _ruleName;
        private string _description;
        private string _property;
        private RuleSeverity _severity;
        private object _link;

        public ExtendedBrokenRule()
        {
        }

        internal ExtendedBrokenRule(BrokenRule rule, object link)
        {
            _ruleName = rule.RuleName;
            _description = rule.Description;
            _property = rule.Property;
            _severity = rule.Severity;
            _link = link;
        }

        /// <summary>
        /// Provides access to the name of the broken rule.
        /// </summary>
        /// <value>The name of the rule.</value>
        public string RuleName
        {
            get { return _ruleName; }
        }

        /// <summary>
        /// Provides access to the description of the broken rule.
        /// </summary>
        /// <value>The description of the rule.</value>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Provides access to the property affected by the broken rule.
        /// </summary>
        /// <value>The property affected by the rule.</value>
        public string Property
        {
            get { return _property; }
        }

        /// <summary>
        /// Gets the severity of the broken rule.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public RuleSeverity Severity
        {
            get { return _severity; }
            set { _severity = value; }
        }

        public object Link
        {
            get { return _link; }
        }

        public override string ToString()
        {
            return _description;
        }

        #region IDuplicateBusiness<ExtendedBrokenRule> Members

        public ExtendedBrokenRule Duplicate()
        {
            var clone = new ExtendedBrokenRule();
            clone._description = _description;
            clone._link = _link;
            clone._property = _property;
            clone._ruleName = _ruleName;
            clone._severity = _severity;

            return clone;
        }

        #endregion
    }
}