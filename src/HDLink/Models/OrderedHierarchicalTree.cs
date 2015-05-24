using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink
{
    /// <summary>
    /// Represents a Tree which has fixed hierarchical levels with ordered childen
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderedHierarchicalTree<T> : IOrderedHierarchicalTree<T> where T : IOrderedHierarchyElement
    {
        private readonly Dictionary<int, List<T>> source;
        
        /// <summary>
        /// Builds empty Tree
        /// </summary>
        public OrderedHierarchicalTree()
        {
            source = new Dictionary<int, List<T>>();
        }

        /// <summary>
        /// Builds Tree from elements
        /// </summary>
        public OrderedHierarchicalTree(IEnumerable<T> elements)
        {
            source = elements.GroupBy(e => e.HierarchyLevel).ToDictionary(g => g.Key,g=>  g.OrderBy(o=> o.Order).ToList());
        }

        /// <summary>
        /// Gets Ordered Enumerable of Elements for a hierarchy
        /// </summary>
        /// <param name="hierarchicalLevel">Hierarchical level</param>
        /// <returns>Ordered Enumerable of Elements</returns>
        public IEnumerable<T> GetHierarchicalLevel(int hierarchicalLevel)
        {
            return source[hierarchicalLevel];
        }

        /// <summary>
        /// Gets List of Hierarchies
        /// </summary>
        public List<int> Hierarchies
        {
            get { return source.Keys.ToList(); }
        }
    }
}
