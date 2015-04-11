using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
        
    /// <summary>
    /// Represents the Type of Node
    /// </summary>
    public interface INodeType<T> :INodeType, IEqualityComparer<INodeType<T>> where T : INode
    {
        

    }

    /// <summary>
    /// Represents the Type of node
    /// </summary>
    public interface INodeType
    {
        /// <summary>
        /// Id used for Identifying INodeType
        /// </summary>
        int Id { get; }
    }
}
