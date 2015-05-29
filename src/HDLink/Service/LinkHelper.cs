using System.Collections.Generic;

namespace HDLink
{
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
