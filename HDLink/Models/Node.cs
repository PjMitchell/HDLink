using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Simplest representation of a node
    /// </summary>
    public class Node: INode
    {
        /// <summary>
        /// Simplest representation of a node
        /// </summary>
        /// <param name="id">Node Id</param>
        /// <param name="nodeType"> Node Type</param>
        public Node(int id, INodeType nodeType)
        {
            Id = id;
            if (nodeType == null)
                throw new ArgumentNullException("nodeType");
            NodeType = nodeType;
        }
        
        /// <summary>
        /// Id used for Identifying Node for NodeType
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Node type for Node
        /// </summary>
        public INodeType NodeType { get; private set; }

        #region Equalities
        public override bool Equals(object obj)
        {
            var node =obj as Node;
            return node != null && Equals(node);
        }

        public bool Equals(Node node)
        {
            return Id == node.Id && NodeType.Id == node.NodeType.Id;
        }

        public override int GetHashCode()
        {
            return hashcode;
        }

        private void SetHashCode()
        {
            int hash = 23;
            unchecked
            {
                hash = hash * 31 + Id;
                hash = hash * 31 + NodeType.Id;
            }
            hashcode = hash;
        }
        private int hashcode = 0;
        #endregion


    }
}
