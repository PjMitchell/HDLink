using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using HDLink.Test.Mocks;
using System.Threading.Tasks;

namespace HDLink.Test.Core
{
    [TestClass]
    public class AsyncNodeServiceTest
    {
        private IAsyncNodeService target;
        private IAsyncLinkRepository linkRepository;
        private IAsyncNodeRepositoryFactory nodeRepoFactory;

        [TestInitialize]
        public void Init()
        {
            linkRepository = new MockLinkRepository();
            nodeRepoFactory = new MockAsyncNodeRepositoryFactory();
            target = new AsyncNodeService(linkRepository, nodeRepoFactory);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NodeService_ThrowsNullException_IfLinkRepositoryNull()
        {
            target = new AsyncNodeService(null, nodeRepoFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NodeService_ThrowsNullException_IfNodeRepositoryFactoryNull()
        {
            target = new AsyncNodeService(linkRepository, null);
        }

        #region Get(Node) Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Get_Node_ThrowsNullException_IfNodeNull()
        {
            var result = await target.Get(null);          
        }

        [TestMethod]
        public async Task Get_Node_ReturnsCorrectResult()
        {
            var result = await target.Get(StoryNode.RedRidingHood);

            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Contains(ActorNode.BigBadWolf));
            Assert.IsTrue(result.Contains(ActorNode.GrannyRidingHood));
            Assert.IsTrue(result.Contains(ActorNode.RedRidingHood));
        }
        #endregion

        #region Get(Node, NodeType) Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Get_Node_NodeType_ThrowsNullException_IfNodeNull()
        {
            var result = await target.Get(null, MockNodeTypes.Story);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Get_Node_NodeType_ThrowsNullException_IfNodeTypeNull()
        {
            var result = await target.Get(ActorNode.BigBadWolf, (INodeType<StoryNode>)null);
        }

        [TestMethod]
        public async Task Get_Node_NodeType_ReturnsCorrectResult()
        {
            var result = await target.Get(ActorNode.BigBadWolf, MockNodeTypes.Story);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(StoryNode.RedRidingHood));
            Assert.IsTrue(result.Contains(StoryNode.ThreeLittlePigs));
        }
        #endregion

        #region Get<T>(Node, NodeType) Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Get_T_Node_NodeType_ThrowsNullException_IfNodeNull()
        {
            var result = await target.Get<StoryNode>(null, MockNodeTypes.Story);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Get_T_Node_NodeType_ThrowsNullException_IfNodeTypeNull()
        {
            var result = await target.Get<StoryNode>(ActorNode.BigBadWolf, null);
        }

        [TestMethod]
        public async Task Get_T_Node_NodeType_ReturnsCorrectResult()
        {
            var result = await target.Get<StoryNode>(ActorNode.BigBadWolf, MockNodeTypes.Story);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(StoryNode.RedRidingHood));
            Assert.IsTrue(result.Contains(StoryNode.ThreeLittlePigs));
        }

        #endregion
    }
}
