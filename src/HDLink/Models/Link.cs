namespace HDLink
{
    /// <summary>
    /// Represents a link between two nodes
    /// </summary>
    /// <typeparam name="A">Node A</typeparam>
    /// <typeparam name="B">Node B</typeparam>
    public class Link<A,B> : ILink  where A : INode where  B :INode     
    {
        /// <summary>
        /// First Node in a Link
        /// </summary>
        public A NodeA { get; set; }
        
        /// <summary>
        /// Second Node in a Link
        /// </summary>
        public B NodeB { get; set; }

        INode ILink.NodeA
        {
            get { return NodeA; }
        }

        INode ILink.NodeB
        {
            get { return NodeB; }
        }

        /// <summary>
        /// Strength of Link
        /// </summary>
        public float Strength {get; set;}
        
        /// <summary>
        /// Direction of Link
        /// </summary>
        public LinkFlow Direction { get; set; }

        /// <summary>
        /// Type of Link
        /// </summary>
        public LinkType Type { get; set; }
    }

    /// <summary>
    /// Represents a Simple link between two basic nodes
    /// </summary>
    public class SimpleLink : Link<Node, Node>
    {
    }
}
