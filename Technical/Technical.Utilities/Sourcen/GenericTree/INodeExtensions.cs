using System;
using System.Collections.Generic;
using System.Linq;

namespace Technical.Utilities.GenericTree
{
// ReSharper disable InconsistentNaming
    public static class ITreeNodeExtensions
// ReSharper restore InconsistentNaming
    {
        /// <summary>
        /// Answers the zero based level of the node, i.e. the root nodes level is zero, the level of the root node childs is 1, and so on.
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <returns>the zero based level of the node</returns>
        public static int Level<T>(this T node) where T : ITreeNode<T>
        {
            return Equals(node.Parent, default(T)) ? 0 : node.Parent.Level() + 1;
        }

        /// <summary>
        /// Find the first descendant node using the filter func.
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <param name="filterFunc"></param>
        /// <returns>the first descendant node or the nodes type default if no node found</returns>
        public static T FirstOrDefaultDescendant<T>(this T node, Predicate<T> filterFunc) where T : ITreeNode<T>
        {
            return filterFunc(node)
                ? node
                : node.Childs.Select(n => n.FirstOrDefaultDescendant(filterFunc))
                    .FirstOrDefault(n => !Equals(n, default(T)));
        }

        /// <summary>
        /// Answers the nodes path as list, first element is the tree root, last element is the node. 
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <returns>The nodes path as list</returns>
        public static IList<T> Path<T>(this T node) where T : ITreeNode<T>
        {
            var list = Equals(node.Parent, default(T)) ? new List<T>() : node.Parent.Path();
            list.Add(node);
            return list;
        }

        /// <summary>
        /// Answers the nods path as string.
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <param name="nodeLabel">the expression used to get the nodes label. If <c>null</c>, the nodes <c>ToString()</c> method is used to get the label.</param>
        /// <param name="separator">the separator used between the nodes in the path</param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// // nodes in path will be labeled using ToString() method
        /// node.PathAsString();
        /// 
        /// // nodes in path will be labeled using property 'Descr'
        /// node.PathAsString(n => n.Descr);
        /// 
        /// // use pipe character as separator between nodes in path
        /// node.PathAsString(n => n.Descr, " | ");  
        /// </code>
        /// </example>
        public static string PathAsString<T>(this T node, Func<T, object> nodeLabel = null, string separator = " > ")
            where T : ITreeNode<T>
        {
            if (nodeLabel == null)
                nodeLabel = n => n.ToString();
            return String.Join(separator, node.Path().Select(nodeLabel));
        }

        /// <summary>
        /// Answers if the node is a root node, i.e. a node with no parent.
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <returns><c>true</c> if the node is parent, <c>false</c> if not</returns>
        public static bool IsRoot<T>(this T node) where T : ITreeNode<T>
        {
            return Equals(node.Parent, default(T));
        }

        /// <summary>
        /// Answers if the node is a leaf node, i.e. a node with no childs.
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <returns><c>true</c> if the node is leaf, <c>false</c> if not</returns>
        public static bool IsLeaf<T>(this T node) where T : ITreeNode<T>
        {
            return node.Childs == null || node.Childs.Count == 0;
        }

        /// <summary>
        /// Answers the depth of the subtree where the root node is this node.
        /// </summary>
        /// <typeparam name="T">the type of the node</typeparam>
        /// <param name="node">the node</param>
        /// <param name="offset">could be negative</param>
        /// <returns></returns>
        public static int TreeDepth<T>(this T node, int offset = 0) where T : ITreeNode<T>
        {
            var depth = Int32.MinValue;
            if (node.Childs == null || node.Childs.Count == 0)
                return offset;
            foreach (var child in node.Childs)
                depth = Math.Max(depth, child.TreeDepth(offset + 1));
            return depth;
        }
    }
}