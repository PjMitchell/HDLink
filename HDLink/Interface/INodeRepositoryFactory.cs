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
        /// <param name="nodeType"></param>
        /// <returns></returns>
        INodeRepository CreateRepository(INodeType nodeType);
    }
}
