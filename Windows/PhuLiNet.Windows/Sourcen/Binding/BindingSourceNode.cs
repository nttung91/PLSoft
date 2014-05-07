using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Windows.Core.Binding
{
    /// <summary>
    /// Manage N-Level of Parent-Child Relations in a Tree of BindingSourceNode's
    /// </summary>
    public class BindingSourceNode
    {
        private readonly List<BindingSourceNode> _bindingSourceChilds;

        /// <summary>
        /// List of Child's (A Child can have Childs again etc)
        /// The list is never null, but can contain 0 Elements when there's no child (Leaf)
        /// </summary>
        public List<BindingSourceNode> BindingSourceChilds
        {
            get { return _bindingSourceChilds; }
        }

        /// <summary>
        /// BindingSource of the Node (Parent)
        /// </summary>
        public BindingSource BindingSource { get; set; }

        /// <summary>
        /// Is this the Root Node
        /// </summary>
        public bool IsRoot { get; set; }

        /// <summary>
        /// Create Root node
        /// </summary>
        /// <param name="bindingSource"></param>
        public BindingSourceNode(BindingSource bindingSource)
        {
            //Empty List of Childs
            _bindingSourceChilds = new List<BindingSourceNode>();
            BindingSource = bindingSource;
            IsRoot = true;
        }

        /// <summary>
        /// Get a node via the nodes Bindingsource
        /// </summary>
        /// <param name="bindingSource">Get node with this BindingSource</param>
        /// <returns>Node that contains this bindingSource, could be null</returns>
        public BindingSourceNode this[BindingSource bindingSource]
        {
            get
            {
                BindingSourceNode res = null;

                foreach (BindingSourceNode node in BindingSourceChilds)
                {
                    if (node.BindingSource == bindingSource)
                    {
                        res = node;
                        break;
                    }
                }

                Debug.Assert(res != null, "BindingSource not in Child List");

                return res;
            }
        }

        /// <summary>
        /// Add Child Nodes
        /// To add Childs to a Masterchild, get the Masterchild node with this command: 
        /// rootNodename[bindingSourceXY].AddChild... 
        /// </summary>
        /// <param name="bindingSource"></param>
        public BindingSourceNode AddChild(BindingSource bindingSource)
        {
            var newBindingSourceNode = new BindingSourceNode(bindingSource);
            newBindingSourceNode.IsRoot = false;
            _bindingSourceChilds.Add(newBindingSourceNode);

            return newBindingSourceNode;
        }
    }
}