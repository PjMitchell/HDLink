using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>Matching Links</returns>
        IEnumerable<ILink> Get(INode node, INodeType nodeType);
    }

    /// <summary>
    /// Repository for Links
    /// </summary>
    public interface IAsyncLinkRepository
    {
        /// <summary>
        /// Get all links in repository
        /// </summary>
        Task<List<ILink>> GetAsync();

        /// <summary>
        /// Gets all ILinks from an INode
        /// </summary>
        /// <param name="node">INode that is Souce of Link</param>
        /// <returns>Avaliable ILinks for INode</returns>
        Task<List<ILink>> GetAsync(INode node);

        /// <summary>
        /// Get all ILinks from an INode that match INodeType
        /// </summary>
        /// <param name="node">INode that is Souce of Link</param>
        /// <param name="nodeType">INodeType To filter on</param>
        /// <returns>Matching Links</returns>
        Task<List<ILink>> GetAsync(INode node, INodeType nodeType);
    }
}
