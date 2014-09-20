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
        /// Gets all ILinks for a INode
        /// </summary>
        /// <param name="node">INode</param>
        /// <returns>Avaliable ILinks for INode</returns>
        IEnumerable<ILink> Get(INode node);
    }
}
