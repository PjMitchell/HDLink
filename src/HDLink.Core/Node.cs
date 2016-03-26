using System.Collections.Generic;

namespace HDLink.Core
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public List<NodeAttribute> Attributes { get; set; }


        public override bool Equals(object obj)
        {
            return Id.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class AttributeDefinition
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public AttributeDataType DataType {get; set;}
        public bool IsPredefined { get; set; }
        public bool AllowMultipleValues { get; set; }
        public override bool Equals(object obj)
        {
            return Definition.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Definition.GetHashCode();
        }
    }

    public enum AttributeDataType
    {
        String = 0
    }

    public class Attribute
    {
        public int Id { get; set; }
        public int DefinitionId { get; set; }
        public AttributeDefinition Definition { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            var attr = obj as Attribute;

            return attr != null && Definition.Equals(attr.Definition) && Value.Equals(attr.Value);
        }

        public override int GetHashCode()
        {
            int hash = 23;
            unchecked
            {
                hash = hash * 31 + Definition.GetHashCode();
                hash = hash * 31 + Value.GetHashCode();
            }
            return hash;
        }
    }

    public class NodeAttribute
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public int Rank { get; set; }
        public Attribute Attribute { get; set; }
    }

    public class Link
    {
        public int Id { get; set; }
        /// <summary>
        /// First Node in a Link
        /// </summary>
        public Node NodeA { get; set; }

        /// <summary>
        /// Second Node in a Link
        /// </summary>
        public Node NodeB { get; set; }

        /// <summary>
        /// Type of Link
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Strength of Link
        /// </summary>
        public float Strength { get; set; }

        /// <summary>
        /// Direction of Link
        /// </summary>
        public LinkFlow Direction { get; set; }

        public override bool Equals(object obj)
        {
            var link = obj as Link;

            return link != null && NodeA.Equals(link.NodeA) && NodeB.Equals(link.NodeB) && Type.Equals(link.Type);
        }

        public override int GetHashCode()
        {
            int hash = 23;
            unchecked
            {
                hash = hash * 31 + NodeA.GetHashCode();
                hash = hash * 31 + NodeB.GetHashCode();
                hash = hash * 31 + Type.GetHashCode();
            }
            return hash;
        }
    }

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
