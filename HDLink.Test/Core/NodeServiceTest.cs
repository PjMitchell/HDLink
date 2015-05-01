using System;
using System.Linq;
using HDLink.Test.Mocks;
using Xunit;

namespace HDLink.Test.Core
{

    public class NodeServiceTest
    {
        private INodeService target;
        private ILinkRepository linkRepository;
        private INodeRepositoryFactory nodeRepoFactory;

        public void Init()
        {
            linkRepository = new MockLinkRepository();
            nodeRepoFactory = new MockNodeRepositoryFactory();
            target = new NodeService(linkRepository, nodeRepoFactory);
        }
        
        [Fact]
        public void NodeService_ThrowsNullException_IfLinkRepositoryNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new NodeService(null, nodeRepoFactory));
        }

        [Fact]
        public void NodeService_ThrowsNullException_IfNodeRepositoryFactoryNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new NodeService(linkRepository, null));
        }

        #region Get(Node) Tests
        [Fact]
        public void Get_Node_ThrowsNullException_IfNodeNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => target.Get(null));          
        }

        [Fact]
        public void Get_Node_ReturnsCorrectResult()
        {
            var result = target.Get(StoryNode.RedRidingHood).ToList();

            Assert.Equal(3, result.Count);
            Assert.True(result.Contains(ActorNode.BigBadWolf));
            Assert.True(result.Contains(ActorNode.GrannyRidingHood));
            Assert.True(result.Contains(ActorNode.RedRidingHood));
        }
        #endregion

        #region Get(Node, NodeType) Tests
        [Fact]
        public void Get_Node_NodeType_ThrowsNullException_IfNodeNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => target.Get(null, MockNodeTypes.Story));
        }

        [Fact]
        public void Get_Node_NodeType_ThrowsNullException_IfNodeTypeNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => target.Get(ActorNode.BigBadWolf, (INodeType<StoryNode>)null));
        }

        [Fact]
        public void Get_Node_NodeType_ReturnsCorrectResult()
        {
            var result = target.Get(ActorNode.BigBadWolf, MockNodeTypes.Story).ToList();

            Assert.Equal(2, result.Count);
            Assert.True(result.Contains(StoryNode.RedRidingHood));
            Assert.True(result.Contains(StoryNode.ThreeLittlePigs));
        }
        #endregion
    }
}
