﻿using System;
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
        /// <param name="repositoryFactory">Factory for the construction of node repositories</param>
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
            if (node == null)
                throw new ArgumentNullException("node");

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
        public IEnumerable<INode> Get(INode node, INodeType nodeType)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (nodeType == null)
                throw new ArgumentNullException("nodeType");
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
        
        private IEnumerable<INode> GetNodesFromRepository(IGrouping<INodeType, INode> group)
        {
            var repo = repositoryFactory.CreateRepository(group.Key);
            return repo.Get(group.Select(s => s.Id));
        }
        
    }

    /// <summary>
    /// Extension methods for Links
    /// </summary>
    internal static class LinkHelper
    {
        /// <summary>
        /// Flattens ILink into its two containing nodess
        /// </summary>
        /// <param name="links">list of links to be flattened</param>
        /// <returns>Nodes from Link</returns>
        public static IEnumerable<INode> Flatten(this IEnumerable<ILink> links)
        {
            foreach (var link in links)
            {
                yield return link.NodeA;
                yield return link.NodeB;
            }
        }

        public static IEnumerable<INode> RemoveNode(this IEnumerable<INode> nodes, INode nodeToRemove)
        {
            foreach (var node in nodes)
            {
                if (node.Id == nodeToRemove.Id && node.NodeType.Id == nodeToRemove.NodeType.Id)
                    continue;
                yield return node;
            }
        }
                
    }
}