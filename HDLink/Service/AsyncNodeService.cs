using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink
{
    /// <summary>
    /// Simple Implementation of INodeService
    /// </summary>
    public class AsyncNodeService : IAsyncNodeService
    {
        private readonly IAsyncLinkRepository linkRepository;
        private readonly IAsyncNodeRepositoryFactory repositoryFactory;
        
        /// <summary>
        /// Simple Implementation of INodeService
        /// </summary>
        /// <param name="linkRepository">Repository for ILinks</param>
        /// <param name="repositoryFactory">Factory for the construction of node repositories</param>
        public AsyncNodeService(IAsyncLinkRepository linkRepository, IAsyncNodeRepositoryFactory repositoryFactory)
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
        public async Task<List<INode>> Get(INode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            var linksForNode = await linkRepository.GetAsync(node);
            var equalityComparer = new BaseNodeEqualityComparator();
            var groups = linksForNode
                .Flatten()
                .RemoveNode(node)
                .Distinct(equalityComparer)
                .GroupBy(g=> g.NodeType).ToArray();
            var tasks = new Task<List<INode>>[groups.Length];
            for(int i = 0; i< groups.Length; i++)
            {
                tasks[i]= GetNodesFromRepository(groups[i].Key, groups[i].Select(s=> s.Id));
            }

            var result = await Task.WhenAll(tasks);
            return result.SelectMany(s=>s).ToList();
                                       
        }

        /// <summary>
        /// Gets All nodes of selected INodeType connected to source node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <param name="nodeType">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        public async Task<List<INode>> Get(INode node, INodeType nodeType)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (nodeType == null)
                throw new ArgumentNullException("nodeType");
            var linksForNode =  await linkRepository.GetAsync(node);
            var equalityComparer = new BaseNodeEqualityComparator();

            var requiredIds = linksForNode
                .Flatten()
                .Where(n => n.NodeType.Equals(nodeType))
                .Distinct(equalityComparer)
                .Select(n => n.Id);
            return await GetNodesFromRepository(nodeType, requiredIds);

        }
        
        private Task<List<INode>> GetNodesFromRepository(INodeType nodeType, IEnumerable<int> ids)
        {
            var repo = repositoryFactory.CreateRepository(nodeType);
            return repo.GetAsync(ids);
        }
        
    }
}
