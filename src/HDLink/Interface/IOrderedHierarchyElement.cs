namespace HDLink
{
    /// <summary>
    /// Represents an element that is ordered in its hierarchy level
    /// </summary>
    public interface IOrderedHierarchyElement
    {
        /// <summary>
        /// Id of element
        /// </summary>
        int Id { get; }
        
        /// <summary>
        /// Id of parent element. -1 
        /// </summary>
        int ParentHierarchyElementId { get; }
        
        /// <summary>
        /// Order of the element within its HierarchyLevel
        /// </summary>
        int Order { get; }
        
        /// <summary>
        /// ELement's Hierarchy Level
        /// </summary>
        int HierarchyLevel { get; }
    }
}
