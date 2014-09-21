﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink.Test.Mocks
{
    class MockNodeType : NodeType
    {
        public MockNodeType(int id, string repositoryKey)
            : base(id, repositoryKey) { }
       

        public static MockNodeType Story { get { return new MockNodeType(1, "StoryRepository"); } }
        public static MockNodeType Actor { get { return new MockNodeType(2,"ActorRepository" ); } }      

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

        public override bool Equals(object obj)
        {
            var node = obj as ActorNode;
            return node != null && node.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;                
        }
    }

    class StoryNode : INode
    {
        public int Id { get; set; }
        public INodeType NodeType { get { return MockNodeType.Story; } }
        public string Title { get; set; }

        public static StoryNode RedRidingHood { get { return new StoryNode { Id = 1, Title = "Red Riding Hood" }; } }
        public static StoryNode ThreeLittlePigs { get { return new StoryNode { Id = 2, Title = "Three Little Pigs" }; } }
        
        public override bool Equals(object obj)
        {
            var node = obj as StoryNode;
            return node != null && node.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
