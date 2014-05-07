using System.Collections.Generic;

namespace Technical.Utilities.GenericTree
{
    /// <summary>
    /// minimal members to define a node in a hierachical tree. Only with public getters to avoid implementation conflicts in CSLA business object implementation.
    /// </summary>
    /// <typeparam name="T">The type of the tree node</typeparam>
    public interface ITreeNode<T> where T : ITreeNode<T>
    {
        /// <summary>
        /// The parent of the tree node. If <c>null</c>, the node is one of the root nodes of the tree.
        /// </summary>
        T Parent { get; }

        /// <summary>
        /// The childs of the tree node. If <c>null</c> or empty, the node is a leaf node of the tree.
        /// </summary>
        IList<T> Childs { get; }
    }
}