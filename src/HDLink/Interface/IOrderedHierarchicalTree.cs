using System.Collections.Generic;

namespace HDLink
{
    /// <summary>
    /// Represents A Hierarchy of IPeriods
    /// </summary>
    /// <typeparam name="T">Type of IPeriod that forms the collection</typeparam>
    public interface IOrderedHierarchicalTree<T> where T : IOrderedHierarchyElement
    {
        /// <summary>
        /// Gets Ordered Enumerable of Elements for a hierarchy
        /// </summary>
        /// <param name="hierarchicalLevel">Hierarchical level</param>
        /// <returns>Ordered Enumerable of Elements</returns>
        IEnumerable<T> GetHierarchicalLevel(int hierarchicalLevel);

        /// <summary>
        /// Gets List of Hierarchies
        /// </summary>
        List<int> Hierarchies { get; }
    }
}
