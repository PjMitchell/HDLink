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

    /// <summary>
    /// Gets Nodes from data source
    /// </summary>
    /// <typeparam name="T">Node type for Repository</typeparam>
    public interface INodeRepository<T> : INodeRepository where T : INode 
    {
        /// <summary>
        /// Gets INode by Id
        /// </summary>
        /// <param name="id">Node Id</param>
        /// <returns>Matching INode</returns>
        T Get(int id);

        /// <summary>
        /// Gets INodes by Ids
        /// </summary>
        /// <param name="ids">Node Ids</param>
        /// <returns>Matching NIodes </returns>
        IEnumerable<T> Get(IEnumerable<int> ids);
    } 

}
