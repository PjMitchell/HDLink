using System.Collections.Generic;

namespace HDLink
{
    /// <summary>
    /// Represents a Node in a Link
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Id used for Identifying INode for INodeType
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Node type for Node
        /// </summary>
        INodeType NodeType {get;} 
    }

   /// <summary>
    /// Defines methods to support the comparison of INode for equality.
   /// </summary>
    public class BaseNodeEqualityComparator : IEqualityComparer<INode>
    {

        /// <summary>
        /// Determines whether the specified INode are equal.
        /// </summary>
        /// <param name="x">The first INode to compare.</param>
        /// <param name="y">The second INode to compare.</param>
        /// <returns> true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(INode x, INode y)
        {
            return x.Id == y.Id && x.NodeType.Id == y.NodeType.Id;
        }

        /// <summary>
        /// Returns a hash code for the specified INode.
        /// </summary>
        /// <param name="obj">The INode for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified INode.</returns>
        public int GetHashCode(INode obj)
        {
            int hash = 23;
            unchecked
            {
                hash = hash * 31 + obj.Id;
                hash = hash * 31 + obj.NodeType.Id;
            }
            return hash;
        }
    }
}
