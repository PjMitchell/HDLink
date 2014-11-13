using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using HDLink.Test.Mocks;

namespace HDLink.Test.Core
{
    [TestClass]
    public class NodeServiceTest
    {
        private INodeService target;
        private ILinkRepository linkRepository;
        private INodeRepositoryFactory nodeRepoFactory;

        [TestInitialize]
        public void Init()
        {
            linkRepository = new MockLinkRepository();
            nodeRepoFactory = new MockNodeRepositoryFactory();
            target = new NodeService(linkRepository, nodeRepoFactory);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NodeService_ThrowsNullException_IfLinkRepositoryNull()
        {
            target = new NodeService(null, nodeRepoFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NodeService_ThrowsNullException_IfNodeRepositoryFactoryNull()
        {
            target = new NodeService(linkRepository, null);
        }

        #region Get(Node) Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Get_Node_ThrowsNullException_IfNodeNull()
        {
            var result = target.Get(null);          
        }

        [TestMethod]
        public void Get_Node_ReturnsCorrectResult()
        {
            var result = target.Get(StoryNode.RedRidingHood).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Contains(ActorNode.BigBadWolf));
            Assert.IsTrue(result.Contains(ActorNode.GrannyRidingHood));
            Assert.IsTrue(result.Contains(ActorNode.RedRidingHood));
        }
        #endregion

        #region Get(Node, NodeType) Tests
        [TestMethod]
        public void Get_Node_NodeType_ThrowsNullException_IfNodeNull()
        {
            var exception = false;
            try
            {
                var result = target.Get(null, MockNodeType.Story);
            }
            catch (ArgumentNullException e)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }

        [TestMethod]
        public void Get_Node_NodeType_ThrowsNullException_IfNodeTypeNull()
        {
            var exception = false;
            try
            {
                var result = target.Get(ActorNode.BigBadWolf, null);
            }
            catch (ArgumentNullException e)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }

        [TestMethod]
        public void Get_Node_NodeType_ReturnsCorrectResult()
        {
            var result = target.Get(ActorNode.BigBadWolf, MockNodeType.Story).ToList();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(StoryNode.RedRidingHood));
            Assert.IsTrue(result.Contains(StoryNode.ThreeLittlePigs));
        }
        #endregion
    }
}
