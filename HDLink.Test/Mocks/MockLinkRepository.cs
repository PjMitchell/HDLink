using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink.Test.Mocks
{
    class MockLinkRepository : ILinkRepository
    {
        public IEnumerable<ILink> Get()
        {

            return new List<SimpleLink>
            {
                new SimpleLink { NodeA = new Node(StoryNode.RedRidingHood.Id, MockNodeType.Story),   NodeB = new Node(ActorNode.RedRidingHood.Id, MockNodeType.Actor)   , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.RedRidingHood.Id, MockNodeType.Story),   NodeB = new Node(ActorNode.BigBadWolf.Id, MockNodeType.Actor)      , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.RedRidingHood.Id, MockNodeType.Story),   NodeB = new Node(ActorNode.GrannyRidingHood.Id, MockNodeType.Actor), Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeType.Story), NodeB = new Node(ActorNode.BigBadWolf.Id, MockNodeType.Actor)      , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeType.Story), NodeB = new Node(ActorNode.PigWithStraw.Id, MockNodeType.Actor)    , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeType.Story), NodeB = new Node(ActorNode.PigWithWood.Id, MockNodeType.Actor)     , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeType.Story), NodeB = new Node(ActorNode.PigWithBrick.Id, MockNodeType.Actor)    , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(ActorNode.RedRidingHood.Id, MockNodeType.Actor), NodeB = new Node(ActorNode.GrannyRidingHood.Id, MockNodeType.Actor)    , Type=MockLinkType.Family },
                new SimpleLink { NodeA = new Node(ActorNode.BigBadWolf.Id, MockNodeType.Actor), NodeB = new Node(ActorNode.GrannyRidingHood.Id, MockNodeType.Actor)    , Type=MockLinkType.WantToEat },
                new SimpleLink { NodeA = new Node(ActorNode.BigBadWolf.Id, MockNodeType.Actor), NodeB = new Node(ActorNode.RedRidingHood.Id, MockNodeType.Actor)    , Type=MockLinkType.WantToEat },
            };
        }

        public IEnumerable<ILink> Get(INode node)
        {
            return Get().Where(w => INodeEqual(w.NodeA, node) || INodeEqual(w.NodeB, node));
        }

        public IEnumerable<ILink> Get(INode node, INodeType nodeType)
        {
            return Get(node).Where(w => (INodeEqual(w.NodeA, node) || w.NodeA.NodeType.Id == nodeType.Id) && (INodeEqual(w.NodeB, node) || w.NodeA.NodeType.Id == nodeType.Id));
        }
        
        private bool INodeEqual(INode one, INode two)
        {
            return one.Id == two.Id && one.NodeType.Id == two.NodeType.Id;
        }
    }

    class MockLinkType : LinkType
    {
        public static LinkType Default { get { return new LinkType { Id = 0, Description = "Default" }; } }
        public static LinkType WantToEat { get {return new LinkType{Id = 1, Description = "Want to Eat"};}}
        public static LinkType Family { get { return new LinkType { Id = 2, Description = "Family" }; } }

    }
}
