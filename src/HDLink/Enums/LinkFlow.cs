namespace HDLink
{
    /// <summary>
    /// Represents the direction of the ILink. Default Bidirectional
    /// </summary>
    public enum LinkFlow
    {
        /// <summary>
        /// Link flows between both nodes
        /// </summary>
        Bidirectional = 0,
        /// <summary>
        /// Link flows from Node A to Node B
        /// </summary>
        AtoB = 1,
        /// <summary>
        /// Link flows from Node B to Node A
        /// </summary>
        BtoA = 2
    }
}
