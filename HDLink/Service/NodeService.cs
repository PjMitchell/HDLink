using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Simple Implementation of INodeService
    /// </summary>
    public class NodeService : INodeService
    {
        private readonly ILinkRepository linkRepository;
        private readonly INodeRepositoryFactory repositoryFactory;
        
        /// <summary>
        /// Simple Implementation of INodeService
        /// </summary>
        /// <param name="linkRepository">Repository for ILinks</param>
        /// <param name="repositoryfactory">Factory for the construction of node repositories</param>
        public NodeService(ILinkRepository linkRepository, INodeRepositoryFactory repositoryFactory)
        {
            if (linkRepository == null)
                throw new ArgumentNullException("linkRepository");
            if (repositoryFactory == null)
                throw new ArgumentNullException("repositoryFactory");
            
            this.linkRepository = linkRepository;
            this.repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Gets All nodes connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Nodes connected source node</returns>
        public IEnumerable<INode> Get(INode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets All nodes of selected INodeType connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <param name="nodeType">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        public IEnumerable<INode> Get(INode node, INodeType nodeType)
        {
            throw new NotImplementedException();
        }
    }
}
