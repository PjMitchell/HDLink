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
            if (nodeType.Id == MockNodeTypes.Actor.Id)
                return new ActorRepository();
            if (nodeType.Id == MockNodeTypes.Story.Id)
                return new StoryRepository();
            throw new ArgumentOutOfRangeException();
        }

        public INodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode
        {
            return (INodeRepository<T>)CreateRepository((INodeType)nodeType);
        }
    }

    public class MockAsyncNodeRepositoryFactory : IAsyncNodeRepositoryFactory
    {
        public IAsyncNodeRepository CreateRepository(INodeType nodeType)
        {
            if (nodeType.Id == MockNodeTypes.Actor.Id)
                return new ActorRepository();
            if (nodeType.Id == MockNodeTypes.Story.Id)
                return new StoryRepository();
            throw new ArgumentOutOfRangeException();
        }

        public IAsyncNodeRepository<T> CreateRepository<T>(INodeType<T> nodeType) where T : INode
        {
            return (IAsyncNodeRepository<T>)CreateRepository((INodeType)nodeType);
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


    public class StoryRepository : INodeRepository<StoryNode>, IAsyncNodeRepository<StoryNode>
    {
        public StoryNode Get(int id)
        {
            return Source().Single(s => s.Id == id);
        }

        public IEnumerable<StoryNode> Get(IEnumerable<int> ids)
        {
            var idSet = new HashSet<int>(ids);
            return Source().Where(s => idSet.Contains(s.Id));
        }

        public Task<StoryNode> GetAsync(int id)
        {
            var tsc = new TaskCompletionSource<StoryNode>();
            tsc.SetResult(Get(id));
            return tsc.Task;
        }

        public Task<List<StoryNode>> GetAsync(IEnumerable<int> ids)
        {
            var tsc = new TaskCompletionSource<List<StoryNode>>();
            tsc.SetResult(Get(ids).ToList());
            return tsc.Task;
        }

        private List<StoryNode> Source()
        {
            return new List<StoryNode>
            {
                StoryNode.RedRidingHood, 
                StoryNode.ThreeLittlePigs
            };
        }

        INode INodeRepository.Get(int id)
        {
            return Get(id);
        }

        IEnumerable<INode> INodeRepository.Get(IEnumerable<int> ids)
        {
            return Get(ids);
        }


        Task<INode> IAsyncNodeRepository.GetAsync(int id)
        {
            var tsc = new TaskCompletionSource<INode>();
            tsc.SetResult(Get(id));
            return tsc.Task;
        }

        Task<List<INode>> IAsyncNodeRepository.GetAsync(IEnumerable<int> ids)
        {
            var tsc = new TaskCompletionSource<List<INode>>();
            tsc.SetResult(Get(ids).ToList<INode>());
            return tsc.Task;
        }
    }
}
