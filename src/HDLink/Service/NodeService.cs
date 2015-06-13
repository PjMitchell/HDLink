using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="repositoryFactory">Factory for the construction of node repositories</param>
        public NodeService(ILinkRepository linkRepository, INodeRepositoryFactory repositoryFactory)
        {
            if (linkRepository == null)
                throw new ArgumentNullException(nameof(linkRepository));
            if (repositoryFactory == null)
                throw new ArgumentNullException(nameof(repositoryFactory));
            
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
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var linksForNode = linkRepository.Get(node);
            var equalityComparer = new BaseNodeEqualityComparator();
            return linksForNode
                .Flatten()
                .RemoveNode(node)
                .Distinct(equalityComparer)
                .GroupBy(g=> g.NodeType)
                .SelectMany(GetNodesFromRepository);                       
        }

        /// <summary>
        /// Gets All nodes of selected INodeType connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <param name="nodeType">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        public IEnumerable<T> Get<T>(INode node, INodeType<T> nodeType) where T : INode
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (nodeType == null)
                throw new ArgumentNullException(nameof(nodeType));
            var linksForNode = linkRepository.Get(node);
            var equalityComparer = new BaseNodeEqualityComparator();

            var requiredIds = linksForNode
                .Flatten()
                .Where(n => n.NodeType.Equals(nodeType))
                .Distinct(equalityComparer)
                .Select(n => n.Id);
            var repo = repositoryFactory.CreateRepository(nodeType);
            return repo.Get(requiredIds);

        }
        
        private IEnumerable<T> GetNodesFromRepository<T>(IGrouping<INodeType<T>, INode> group) where T: INode
        {
            var repo = repositoryFactory.CreateRepository(group.Key);
            return repo.Get(group.Select(s => s.Id));
        }

        private IEnumerable<INode> GetNodesFromRepository(IGrouping<INodeType, INode> group)
        {
            var repo = repositoryFactory.CreateRepository(group.Key);
            return repo.Get(group.Select(s => s.Id));
        }

    }

    
}
