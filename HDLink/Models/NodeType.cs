using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Represents a the Type of Node
    /// </summary>
    public class NodeType<T> : INodeType<T> where T : INode
    {
        /// <summary>
        /// Represents a the Type of Node
        /// </summary>
        /// <param name="id">Node Type Id</param>
        /// <param name="nodeTypeRepositoryKey">Key used to Idenfity Repository for INodeType</param>
        public NodeType(int id)
        {
            Id = id;    
        }
        
        /// <summary>
        /// Id used for Identifying INodeType
        /// </summary>
        public int Id { get; private set; }


        public bool Equals(INodeType<T> x, INodeType<T> y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(INodeType<T> obj)
        {
            return obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var nodeType = obj as NodeType<T>;
            return nodeType != null && nodeType.Id == Id;
        } 
    }
}
