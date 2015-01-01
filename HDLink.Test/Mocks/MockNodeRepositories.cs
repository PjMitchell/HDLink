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

    public class MockAsyncNodeRepositoryFactory : IAsyncNodeRepositoryFactory
    {
        public IAsyncNodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType.Id == MockNodeType.Actor.Id)
                return new ActorRepository();
            if (nodeType.Id == MockNodeType.Story.Id)
                return new StoryRepository();
            throw new ArgumentOutOfRangeException();
        }
    }

    public class ActorRepository : INodeRepository, IAsyncNodeRepository
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

        public Task<INode> GetAsync(int id)
        {
            var tsc = new TaskCompletionSource<INode>();
            tsc.SetResult(Get(id));
            return tsc.Task;
        }

        public Task<List<INode>> GetAsync(IEnumerable<int> ids)
        {
            var tsc = new TaskCompletionSource<List<INode>>();
            tsc.SetResult(Get(ids).ToList());
            return tsc.Task;
        }
    }


    public class StoryRepository : INodeRepository, IAsyncNodeRepository
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

        public Task<INode> GetAsync(int id)
        {
            var tsc = new TaskCompletionSource<INode>();
            tsc.SetResult(Get(id));
            return tsc.Task;
        }

        public Task<List<INode>> GetAsync(IEnumerable<int> ids)
        {
            var tsc = new TaskCompletionSource<List<INode>>();
            tsc.SetResult(Get(ids).ToList());
            return tsc.Task;
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
