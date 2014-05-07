using System.Collections;
using Csla.Core;
using PhuLiNet.Business.Common.Interfaces;
using PhuLiNet.Business.Common.Navigator.Interfaces;
using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.Navigator
{
    public class TreeBuilder
    {
        private int _uid = 0;

        public ITreeNodeList BusinessObjectTree { get; private set; }

        public TreeBuilder()
        {
            BusinessObjectTree = new TreeNodeList();
        }

        public int BuildTreeNode(BusinessBase businessObject, int parentId, bool initiallyExpanded)
        {
            int id = GetUid();
            if (BusinessObjectTree != null)
            {
                var brokenRulesCollector = new BrokenRulesCollector(businessObject);
                brokenRulesCollector.Collect();
                BusinessObjectTree.Add(new TreeNode(id, parentId, ((IDisplayTexts) businessObject).ToDisplayText(),
                    businessObject, brokenRulesCollector.BrokenRules, initiallyExpanded));
            }
            return id;
        }

        public int BuildTreeNodesFromListAndChilds(IList list, int parentId, bool initiallyExpanded)
        {
            int id = GetUid();
            if (BusinessObjectTree != null)
            {
                BusinessObjectTree.Add(new TreeNode(id, parentId, ((IDisplayTexts) list).ToDisplayText(), list, null,
                    initiallyExpanded));

                parentId = id;
                foreach (BusinessBase businessObject in list)
                {
                    id = GetUid();
                    var brokenRulesCollector = new BrokenRulesCollector(businessObject);
                    brokenRulesCollector.Collect();
                    BusinessObjectTree.Add(new TreeNode(id, parentId, ((IDisplayTexts) businessObject).ToDisplayText(),
                        businessObject, brokenRulesCollector.BrokenRules, initiallyExpanded));
                }
            }
            return id;
        }

        public int BuildTreeNodesFromListWithoutChilds(IList list, int parentId, bool initiallyExpanded)
        {
            int id = GetUid();
            if (BusinessObjectTree != null)
            {
                BusinessObjectTree.Add(new TreeNode(id, parentId, ((IDisplayTexts) list).ToDisplayText(), list, null,
                    initiallyExpanded));
                parentId = id;
            }
            return id;
        }

        private int GetUid()
        {
            if (_uid == int.MaxValue) _uid = 0;

            _uid++;
            return _uid;
        }
    }
}