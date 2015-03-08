using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink
{
    /// <summary>
    /// Gathers Nodes From Links
    /// </summary>
    public interface INodeService
    {
        /// <summary>
        /// Gets All nodes connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Nodes connected source node</returns>
        IEnumerable<INode> Get(INode node);

        /// <summary>
        /// Gets All nodes of selected INodeType connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <param name="nodeType">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        IEnumerable<T> Get<T>(INode node, INodeType<T> nodeType) where T : INode;
    }

    /// <summary>
    /// Gathers Nodes From Links
    /// </summary>
    public interface IAsyncNodeService
    {
        /// <summary>
        /// Gets All nodes connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Nodes connected source node</returns>
        Task<List<INode>> Get(INode node);

        /// <summary>
        /// Gets All nodes of selected INodeType connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <param name="nodeType">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        Task<List<T>> Get<T>(INode node, INodeType<T> nodeType) where T : INode;

    }
}
