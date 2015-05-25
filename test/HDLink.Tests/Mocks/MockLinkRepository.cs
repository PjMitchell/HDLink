using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink.Test.Mocks
{
    class MockLinkRepository : ILinkRepository, IAsyncLinkRepository
    {
        public IEnumerable<ILink> Get()
        {

            return new List<SimpleLink>
            {
                new SimpleLink { NodeA = new Node(StoryNode.RedRidingHood.Id, MockNodeTypes.Story),   NodeB = new Node(ActorNode.RedRidingHood.Id, MockNodeTypes.Actor)   , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.RedRidingHood.Id, MockNodeTypes.Story),   NodeB = new Node(ActorNode.BigBadWolf.Id, MockNodeTypes.Actor)      , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.RedRidingHood.Id, MockNodeTypes.Story),   NodeB = new Node(ActorNode.GrannyRidingHood.Id, MockNodeTypes.Actor), Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeTypes.Story), NodeB = new Node(ActorNode.BigBadWolf.Id, MockNodeTypes.Actor)      , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeTypes.Story), NodeB = new Node(ActorNode.PigWithStraw.Id, MockNodeTypes.Actor)    , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeTypes.Story), NodeB = new Node(ActorNode.PigWithWood.Id, MockNodeTypes.Actor)     , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(StoryNode.ThreeLittlePigs.Id, MockNodeTypes.Story), NodeB = new Node(ActorNode.PigWithBrick.Id, MockNodeTypes.Actor)    , Type=MockLinkType.Default },
                new SimpleLink { NodeA = new Node(ActorNode.RedRidingHood.Id, MockNodeTypes.Actor), NodeB = new Node(ActorNode.GrannyRidingHood.Id, MockNodeTypes.Actor)    , Type=MockLinkType.Family },
                new SimpleLink { NodeA = new Node(ActorNode.BigBadWolf.Id, MockNodeTypes.Actor), NodeB = new Node(ActorNode.GrannyRidingHood.Id, MockNodeTypes.Actor)    , Type=MockLinkType.WantToEat },
                new SimpleLink { NodeA = new Node(ActorNode.BigBadWolf.Id, MockNodeTypes.Actor), NodeB = new Node(ActorNode.RedRidingHood.Id, MockNodeTypes.Actor)    , Type=MockLinkType.WantToEat },
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

        public Task<List<ILink>> GetAsync()
        {
            var tsc = new TaskCompletionSource<List<ILink>>();
            tsc.SetResult(Get().ToList());
            return tsc.Task;
        }

        public Task<List<ILink>> GetAsync(INode node)
        {
            var tsc = new TaskCompletionSource<List<ILink>>();
            tsc.SetResult(Get(node).ToList());
            return tsc.Task;
        }

        public Task<List<ILink>> GetAsync(INode node, INodeType nodeType)
        {
            var tsc = new TaskCompletionSource<List<ILink>>();
            tsc.SetResult(Get(node, nodeType).ToList());
            return tsc.Task;
        }
    }

    class MockLinkType : LinkType
    {
        public static LinkType Default { get { return new LinkType { Id = 0, Description = "Default" }; } }
        public static LinkType WantToEat { get {return new LinkType{Id = 1, Description = "Want to Eat"};}}
        public static LinkType Family { get { return new LinkType { Id = 2, Description = "Family" }; } }

    }
}
