using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Represents a the Type of Node
    /// </summary>
    public class NodeType : INodeType
    {
        /// <summary>
        /// Represents a the Type of Node
        /// </summary>
        /// <param name="id">Node Type Id</param>
        /// <param name="nodeTypeRepositoryKey">Key used to Idenfity Repository for INodeType</param>
        public NodeType(int id, string nodeTypeRepositoryKey)
        {
            if (nodeTypeRepositoryKey == null)
                throw new ArgumentNullException();
            Id = id;
            NodeTypeRepositoryKey = nodeTypeRepositoryKey;
        }
        
        /// <summary>
        /// Id used for Identifying INodeType
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Key used to Idenfity Repository for INodeType
        /// </summary>
        public string NodeTypeRepositoryKey { get; private set; }

        public bool Equals(INodeType x, INodeType y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(INodeType obj)
        {
            return obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var nodeType = obj as NodeType;
            return nodeType != null && nodeType.Id == Id;
        } 
    }
}
