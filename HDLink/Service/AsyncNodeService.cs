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
        private static readonly BaseNodeEqualityComparator equalityComparer = new BaseNodeEqualityComparator();
        
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
            CheckParameters(node, nodeType);
            var linksForNode =  await linkRepository.GetAsync(node);
            var requiredIds = GetIdsForNodeType(nodeType, linksForNode);
            return await GetNodesFromRepository(nodeType, requiredIds);

        }

        /// <summary>
        /// Gets All nodes of selected INodeType connected to source node cast to an expected nodetype
        /// </summary>
        /// <typeparam name="T">Type of INode to be cast to</typeparam>
        /// <param name="node">Source node</param>
        /// <param name="nodeType">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        public async Task<List<T>> Get<T>(INode node, INodeType nodeType) where T : INode
        {
            CheckParameters(node, nodeType);
            var linksForNode = await linkRepository.GetAsync(node);
            var requiredIds = GetIdsForNodeType(nodeType, linksForNode);
            var rawList = await GetNodesFromRepository(nodeType, requiredIds);
            return rawList.Cast<T>().ToList();
        }
        private static IEnumerable<int> GetIdsForNodeType(INodeType nodeType, List<ILink> linksForNode)
        {
            var requiredIds = linksForNode
                .Flatten()
                .Where(n => n.NodeType.Equals(nodeType))
                .Distinct(equalityComparer)
                .Select(n => n.Id);
            return requiredIds;
        }  

        private static void CheckParameters(INode node, INodeType nodeType)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (nodeType == null)
                throw new ArgumentNullException("nodeType");
        }

        private Task<List<INode>> GetNodesFromRepository(INodeType nodeType, IEnumerable<int> ids)
        {
            var repo = repositoryFactory.CreateRepository(nodeType);
            return repo.GetAsync(ids);
        }



        
    }
}
