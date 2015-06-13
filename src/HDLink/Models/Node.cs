using System;

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
        /// <param name="nodeType">Node Type</param>
        public Node(int id, INodeType nodeType)
        {
            Id = id;
            if (nodeType == null)
                throw new ArgumentNullException("nodeType");
            NodeType = nodeType;
            SetHashCode();
        }
        
        /// <summary>
        /// Id used for Identifying Node for NodeType
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Node type for Node
        /// </summary>
        public INodeType NodeType { get; }


        #region Equalities
        /// <summary>
        /// Determines whether the object is equal to the Node.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>if the object is equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var node =obj as Node;
            return node != null && Equals(node);
        }

        /// <summary>
        /// Determines whether the node is equal to the instance.
        /// </summary>
        /// <param name="node">The node to compare to.</param>
        /// <returns>if the node is equal; otherwise, false.</returns>
        public bool Equals(Node node) => Id == node.Id && NodeType.Id == node.NodeType.Id;

        /// <summary>
        /// Returns a hash code for the Node.
        /// </summary>
        /// <returns>A hash code for the specified Node.</returns>
        public override int GetHashCode() => hashcode;


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
