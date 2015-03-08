using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDLink
{
    /// <summary>
    /// Generates Node Repository from INodeType
    /// </summary>
    public interface INodeRepositoryFactory
    {
        /// <summary>
        /// Creates a INodeRepository For INodeType
        /// </summary>
        /// <typeparam name="T">INode type returned by the repository</typeparam>
        /// <param name="nodeType">node type used to generate the repository</param>
        /// <returns>INodeRepository For INodeType</returns>
        INodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode;

        /// <summary>
        /// Creates a INodeRepository For INodeType
        /// </summary>
        /// <param name="nodeType">node type used to generate the repository</param>
        /// <returns>INodeRepository For INodeType</returns>
        INodeRepository CreateRepository(INodeType nodeType);
    }

    /// <summary>
    /// Generates Node Repository from INodeType
    /// </summary>
    public interface IAsyncNodeRepositoryFactory
    {
        /// <summary>
        /// Creates a IAsyncNodeRepository For INodeType
        /// </summary>
        /// <typeparam name="T">INode type returned by the repository</typeparam>
        /// <param name="nodeType">node type used to generate the repository</param>
        /// <returns>INodeRepository For INodeType</returns>
        IAsyncNodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode ;

        /// <summary>
        /// Creates a IAsyncNodeRepository For INodeType
        /// </summary>
        /// <param name="nodeType">node type used to generate the repository</param>
        /// <returns>IAsyncNodeRepository For INodeType</returns>
        IAsyncNodeRepository CreateRepository(INodeType nodeType);
    }
}
