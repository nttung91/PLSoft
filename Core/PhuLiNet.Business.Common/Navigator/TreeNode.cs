using System;
using Csla.Core;
using PhuLiNet.Business.Common.Navigator.Interfaces;
using PhuLiNet.Business.Common.Rules;

namespace PhuLiNet.Business.Common.Navigator
{
    public class TreeNode : TreeNodeBase, ITreeNode
    {
        public TreeNode(int id, int parentID, string description, object link, ExtendedBrokenRulesCollection brokenRules,
            bool initiallyExpanded)
            : base(id, parentID, description)
        {
            Link = link;
            BrokenRules = brokenRules;
            InitiallyExpanded = initiallyExpanded;
        }

        public ExtendedBrokenRulesCollection BrokenRules { get; private set; }

        #region ITreeNode Members

        public object Link { get; private set; }
        public object LinkIcon { get; set; }
        public bool InitiallyExpanded { get; private set; }

        public bool IsValid
        {
            get
            {
                bool result = true;
                if (Link != null && Link is BusinessBase)
                {
                    result = ((BusinessBase) Link).IsValid;
                }
                return result;
            }
        }

        public string BrokenRulesPreview
        {
            get
            {
                string result = string.Empty;
                if (BrokenRules != null)
                {
                    for (int i = 0; i < BrokenRules.Count; i++)
                    {
                        if (i > 0)
                            result += Environment.NewLine;

                        result += (BrokenRules[i]).Description;
                    }
                }
                return result;
            }
        }

        #endregion
    }
}