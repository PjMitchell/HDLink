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
        public NodeType(int id)
        {
            Id = id;    
        }
        
        /// <summary>
        /// Id used for Identifying INodeType
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Determines whether the specified INodeType are equal.
        /// </summary>
        /// <param name="x">The first object of INodeType to compare.</param>
        /// <param name="y">The second object of INodeType to compare.</param>
        /// <returns> true if the specified INodeType are equal; otherwise, false.</returns>
        public bool Equals(INodeType<T> x, INodeType<T> y)
        {
            return x.Id == y.Id;
        }

        /// <summary>
        /// Returns a hash code for the specified INodeType.
        /// </summary>
        /// <param name="obj">The INodeType for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified INodeType.</returns>
        public int GetHashCode(INodeType<T> obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Returns a hash code for the INodeType.
        /// </summary>
        /// <returns>The hash code for INodeType</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the object is equal to the NodeType.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>true if the object is equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var nodeType = obj as NodeType<T>;
            return nodeType != null && nodeType.Id == Id;
        } 
    }
}
