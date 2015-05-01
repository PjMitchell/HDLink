using System;
using HDLink.Test.Mocks;
using System.Threading.Tasks;
using Xunit;

namespace HDLink.Test.Core
{
    public class AsyncNodeServiceTest
    {
        private IAsyncNodeService target;
        private IAsyncLinkRepository linkRepository;
        private IAsyncNodeRepositoryFactory nodeRepoFactory;

        public AsyncNodeServiceTest()
        {
            linkRepository = new MockLinkRepository();
            nodeRepoFactory = new MockAsyncNodeRepositoryFactory();
            target = new AsyncNodeService(linkRepository, nodeRepoFactory);
        }


        [Fact]
        public void NodeService_ThrowsNullException_IfLinkRepositoryNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new AsyncNodeService(null, nodeRepoFactory));
        }

        [Fact]
        public void NodeService_ThrowsNullException_IfNodeRepositoryFactoryNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new AsyncNodeService(linkRepository, null));
        }

        #region Get(Node) Tests
        [Fact]
        public async Task Get_Node_ThrowsNullException_IfNodeNull()
        {
            await Assert.ThrowsAsync(typeof(ArgumentNullException), () => target.Get(null));          
        }

        [Fact]
        public async Task Get_Node_ReturnsCorrectResult()
        {
            var result = await target.Get(StoryNode.RedRidingHood);

            Assert.Equal(3, result.Count);
            Assert.True(result.Contains(ActorNode.BigBadWolf));
            Assert.True(result.Contains(ActorNode.GrannyRidingHood));
            Assert.True(result.Contains(ActorNode.RedRidingHood));
        }
        #endregion

        #region Get(Node, NodeType) Tests
        [Fact]
        public async Task Get_Node_NodeType_ThrowsNullException_IfNodeNull()
        {
            await Assert.ThrowsAsync(typeof(ArgumentNullException), () => target.Get(null, MockNodeTypes.Story));
        }

        [Fact]
        public async Task Get_Node_NodeType_ThrowsNullException_IfNodeTypeNull()
        {
            await Assert.ThrowsAsync(typeof(ArgumentNullException), () => target.Get(ActorNode.BigBadWolf, (INodeType<StoryNode>)null));
        }

        [Fact]
        public async Task Get_Node_NodeType_ReturnsCorrectResult()
        {
            var result = await target.Get(ActorNode.BigBadWolf, MockNodeTypes.Story);

            Assert.Equal(2, result.Count);
            Assert.True(result.Contains(StoryNode.RedRidingHood));
            Assert.True(result.Contains(StoryNode.ThreeLittlePigs));
        }
        #endregion

        #region Get<T>(Node, NodeType) Tests
        [Fact]
        public async Task Get_T_Node_NodeType_ThrowsNullException_IfNodeNull()
        {
            await Assert.ThrowsAsync(typeof(ArgumentNullException), () => target.Get(null, MockNodeTypes.Story));
        }

        [Fact]
        public async Task Get_T_Node_NodeType_ThrowsNullException_IfNodeTypeNull()
        {
            await Assert.ThrowsAsync(typeof(ArgumentNullException), () => target.Get<StoryNode>(ActorNode.BigBadWolf, null));
        }

        [Fact]
        public async Task Get_T_Node_NodeType_ReturnsCorrectResult()
        {
            var result = await target.Get(ActorNode.BigBadWolf, MockNodeTypes.Story);

            Assert.Equal(2, result.Count);
            Assert.True(result.Contains(StoryNode.RedRidingHood));
            Assert.True(result.Contains(StoryNode.ThreeLittlePigs));
        }

        #endregion
    }
}
