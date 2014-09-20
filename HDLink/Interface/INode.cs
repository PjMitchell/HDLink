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
}
