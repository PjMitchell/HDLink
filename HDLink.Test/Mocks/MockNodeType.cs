using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink.Test.Mocks
{
    class MockNodeType : INodeType
    {

        public int Id { get; set; }
        public string NodeTypeRepositoryKey { get; set; }

        public static MockNodeType Story { get { return new MockNodeType { Id = 1, NodeTypeRepositoryKey = "StoryRepository" }; } }
        public static MockNodeType Actor { get { return new MockNodeType {Id =2, NodeTypeRepositoryKey ="ActorRepository" }; } }
    }

    class ActorNode : INode
    {
        public int Id { get; set; }
        public INodeType NodeType { get { return MockNodeType.Actor; } }
        public string Name { get; set; }

        public static ActorNode RedRidingHood { get { return new ActorNode { Id = 1, Name = "Red Riding Hood" }; } }
        public static ActorNode BigBadWolf { get { return new ActorNode { Id = 2, Name = "Big Bad Wolf" }; } }
        public static ActorNode GrannyRidingHood { get { return new ActorNode { Id = 3, Name = "Granny Riding Hood" }; } }
        public static ActorNode PigWithStraw { get { return new ActorNode { Id = 4, Name = "Pig With Straw" }; } }
        public static ActorNode PigWithWood { get { return new ActorNode { Id = 5, Name = "Pig With Wood" }; } }
        public static ActorNode PigWithBrick { get { return new ActorNode { Id = 6, Name = "Pig With Brick" }; } }
        
    }

    class StoryNode : INode
    {
        public int Id { get; set; }
        public INodeType NodeType { get { return MockNodeType.Story; } }
        public string Title { get; set; }

        public static StoryNode RedRidingHood { get { return new StoryNode { Id = 1, Title = "Red Riding Hood" }; } }
        public static StoryNode ThreeLittlePigs { get { return new StoryNode { Id = 2, Title = "Three Little Pigs" }; } }

    }
}
