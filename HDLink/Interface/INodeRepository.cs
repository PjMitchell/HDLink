using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Gets INode by Id
    /// </summary>
    public interface INodeRepository
    {
        /// <summary>
        /// Gets INode by Id
        /// </summary>
        /// <param name="id">Node Id</param>
        /// <returns>Matching INode</returns>
        INode Get(int id);

        /// <summary>
        /// Gets INodes by Ids
        /// </summary>
        /// <param name="ids">Node Ids</param>
        /// <returns>Matching NIodes </returns>
        IEnumerable<INode> Get(IEnumerable<int> ids);
    }
}
