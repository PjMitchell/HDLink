using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Repository for Links
    /// </summary>
    public interface ILinkRepository
    {
        /// <summary>
        /// Get all links in repository
        /// </summary>
        IEnumerable<ILink> Get();

        /// <summary>
        /// Gets all ILinks from an INode
        /// </summary>
        /// <param name="node">INode that is Souce of Link</param>
        /// <returns>Avaliable ILinks for INode</returns>
        IEnumerable<ILink> Get(INode node);

        /// <summary>
        /// Get all ILinks from an INode that match INodeType
        /// </summary>
        /// <param name="node">INode that is Souce of Link</param>
        /// <param name="nodeType">INodeType To filter on</param>
        /// <returns></returns>
        IEnumerable<ILink> Get(INode node, INodeType nodeType);
    }
}
