using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public class BaseNodeEqualityComparator : IEqualityComparer<INode>
    {

        public bool Equals(INode x, INode y)
        {
            return x.Id == y.Id && x.NodeType.Id == y.NodeType.Id;
        }

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
