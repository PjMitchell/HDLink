using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Represents a the Type of Node
    /// </summary>
    public interface INodeType
    {
        /// <summary>
        /// Id used for Identifying INodeType
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Key used to Idenfity Repository for INodeType
        /// </summary>
        string NodeTypeRepositoryKey { get;} 
    }
}
