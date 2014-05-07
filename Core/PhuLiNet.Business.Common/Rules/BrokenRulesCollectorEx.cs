using Csla.Rules;

namespace PhuLiNet.Business.Common.Rules
{
    /// <summary>
    /// Collects broken business rules from root business object and all child objects
    /// </summary>
    public class BrokenRulesCollectorEx : IBrokenRulesCollector
    {
        private readonly IBrokenBusinessRules _rootObject;
        private readonly ExtendedBrokenRulesCollection _brokenRules;

        public ExtendedBrokenRulesCollection BrokenRules
        {
            get { return _brokenRules; }
        }

        public BrokenRulesCollectorEx(IBrokenBusinessRules rootObject)
        {
            _rootObject = rootObject;
            _brokenRules = new ExtendedBrokenRulesCollection();
        }

        public void Collect()
        {
            _brokenRules.ClearBrokenRules();

            BrokenRulesTree brokenRulesTree = _rootObject.GetAllBrokenRules();

            if (brokenRulesTree != null)
            {
                foreach (BrokenRulesNode node in brokenRulesTree)
                {
                    CollectBrokenRules(node);
                }
            }
        }

        private void CollectBrokenRules(BrokenRulesNode node)
        {
            if (node != null && node.BrokenRules != null)
            {
                foreach (BrokenRule rule in node.BrokenRules)
                {
                    _brokenRules.Add(rule, node.Object);
                }
            }
        }

        public static string GetBrokenRulesAsString(IBrokenBusinessRules rootObject)
        {
            var brokenRulesCollector = new BrokenRulesCollectorEx(rootObject);
            brokenRulesCollector.Collect();

            if (brokenRulesCollector.BrokenRules != null)
            {
                return brokenRulesCollector.BrokenRules.ToString();
            }

            return string.Empty;
        }
    }
}