using Csla.Core;
using Csla.Rules;

namespace PhuLiNet.Business.Common.Rules
{
    /// <summary>
    /// Collects broken business rules from business object
    /// </summary>
    internal class BrokenRulesCollector : IBrokenRulesCollector
    {
        private BusinessBase _businessObject;
        private ExtendedBrokenRulesCollection _brokenRules;

        public ExtendedBrokenRulesCollection BrokenRules
        {
            get { return _brokenRules; }
        }

        public BrokenRulesCollector(BusinessBase businessObject)
        {
            _businessObject = businessObject;
            _brokenRules = new ExtendedBrokenRulesCollection();
        }

        public void Collect()
        {
            Collect(_businessObject);
        }

        private void Collect(BusinessBase businessObject)
        {
            if (_brokenRules != null)
            {
                foreach (BrokenRule br in businessObject.BrokenRulesCollection)
                {
                    _brokenRules.Add(br, businessObject);
                }
            }
        }
    }
}