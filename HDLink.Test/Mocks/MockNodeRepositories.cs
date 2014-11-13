using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink.Test.Mocks
{
    public class MockNodeRepositoryFactory : INodeRepositoryFactory
    {
        public INodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType.Id == MockNodeType.Actor.Id)
                return new ActorRepository();
            if (nodeType.Id == MockNodeType.Story.Id)
                return new StoryRepository();
            throw new ArgumentOutOfRangeException();
        }
    }

    public class ActorRepository : INodeRepository
    {
        public INode Get(int id)
        {
            return Source().Single(s => s.Id == id);
        }

        public IEnumerable<INode> Get(IEnumerable<int> ids)
        {
            var idSet = new HashSet<int>(ids);
            return Source().Where(s => idSet.Contains(s.Id));
        }

        private List<INode> Source()
        {
            return new List<INode>
            {
                ActorNode.BigBadWolf,ActorNode.GrannyRidingHood, 
                ActorNode.PigWithBrick, 
                ActorNode.PigWithStraw, 
                ActorNode.PigWithWood, 
                ActorNode.RedRidingHood
            };
        }
    }


    public class StoryRepository : INodeRepository
    {
        public INode Get(int id)
        {
            return Source().Single(s => s.Id == id);
        }

        public IEnumerable<INode> Get(IEnumerable<int> ids)
        {
            var idSet = new HashSet<int>(ids);
            return Source().Where(s => idSet.Contains(s.Id));
        }

        private List<INode> Source()
        {
            return new List<INode>
            {
                StoryNode.RedRidingHood, 
                StoryNode.ThreeLittlePigs
            };
        }
    }
}
