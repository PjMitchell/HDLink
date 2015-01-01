using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public interface INodeRepository<T> where T : INode 
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

    /// <summary>
    /// Gets INode by Id
    /// </summary>
    public interface IAsyncNodeRepository
    {
        /// <summary>
        /// Gets INode by Id
        /// </summary>
        /// <param name="id">Node Id</param>
        /// <returns>Matching INode</returns>
        Task<INode> GetAsync(int id);

        /// <summary>
        /// Gets INodes by Ids
        /// </summary>
        /// <param name="ids">Node Ids</param>
        /// <returns>Matching NIodes </returns>
        Task<List<INode>> GetAsync(IEnumerable<int> ids);
    }

    /// <summary>
    /// Gets Nodes from data source
    /// </summary>
    /// <typeparam name="T">Node type for Repository</typeparam>
    public interface IAsyncNodeRepository<T> where T : INode
    {
        /// <summary>
        /// Gets INode by Id
        /// </summary>
        /// <param name="id">Node Id</param>
        /// <returns>Matching INode</returns>
        Task<T> Get(int id);

        /// <summary>
        /// Gets INodes by Ids
        /// </summary>
        /// <param name="ids">Node Ids</param>
        /// <returns>Matching NIodes </returns>
        Task<List<T>> Get(IEnumerable<int> ids);
    }
}
