﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="nameof(linkRepository)">Repository for ILinks</param>
        /// <param name="nameof(repositoryFactory)">Factory for the construction of node repositories</param>
        public AsyncNodeService(IAsyncLinkRepository linkRepository, IAsyncNodeRepositoryFactory repositoryFactory)
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
        /// <param name="nameof(node)">Source node</param>
        /// <returns>Nodes connected source node</returns>
        public async Task<List<INode>> Get(INode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

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
        /// <param name="nameof(node)">Source node</param>
        /// <param name="nameof(nodeType)">Node type to filter nodes on</param>
        /// <returns>Nodes connected source node</returns>
        public async Task<List<T>> Get<T>(INode node, INodeType<T> nodeType) where T : INode
        {
            CheckParameters(node, nodeType);
            var linksForNode =  await linkRepository.GetAsync(node);
            var requiredIds = GetIdsForNodeType(nodeType, linksForNode);
            return await GetNodesFromRepository(nodeType, requiredIds);

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
                throw new ArgumentNullException(nameof(node));
            if (nodeType == null)
                throw new ArgumentNullException(nameof(nodeType));
        }

        private Task<List<T>> GetNodesFromRepository<T>(INodeType<T> nodeType, IEnumerable<int> ids) where T : INode
        {
            var repo = repositoryFactory.CreateRepository(nodeType);
            return repo.GetAsync(ids);
        }

        private Task<List<INode>> GetNodesFromRepository(INodeType nodeType, IEnumerable<int> ids) 
        {
            var repo = repositoryFactory.CreateRepository(nodeType);
            return repo.GetAsync(ids);
        }



        
    }
}
