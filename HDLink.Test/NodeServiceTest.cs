using HDLink.Test.Mocks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLink.Test
{
    [TestClass]
    public class NodeServiceTest
    {
        private INodeService target;
        
        [TestInitialize]
        public void Init()
        {
            target = new NodeService(new MockLinkRepository(), new MockNodeRepositoryFactory());
        }
    

        [TestMethod]
        public void NodeService_ThrowsNullException_IfLinkRepositoryNull()
        {
            var exception = false;
            try
            {
                target = new NodeService(null, new MockNodeRepositoryFactory());
            }
            catch (ArgumentNullException e)
            {
                exception = true;
            }

            Assert.IsTrue(exception);

        }

        [TestMethod]
        public void NodeService_ThrowsNullException_IfNodeRepositoryFactoryNull()
        {
            var exception = false;
            try
            {
                target = new NodeService(new MockLinkRepository(), null);
            }
            catch (ArgumentNullException e)
            {
                exception = true;
            }

            Assert.IsTrue(exception);

        }

        #region Get(Node) Tests
        [TestMethod]
        public void Get_Node_ThrowsNullException_IfNodeNull()
        {
            var exception = false;
            try
            {
                var result = target.Get(null);
            }
            catch (ArgumentNullException e)
            {
                exception = true;
            }

            Assert.IsTrue(exception);

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
