using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HDLink.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HDLink.Test.Core
{
    [TestClass]
    public class NodeTypeTest
    {

        [TestMethod]
        public void NodeType_EqualitiesWorks()
        {

            Assert.AreEqual(new NodeType<Node>(1), new NodeType<Node>(1));
            Assert.AreNotEqual(new NodeType<Node>(1), new NodeType<Node>(2));
            Assert.AreNotEqual(new NodeType<ActorNode>(1), new NodeType<StoryNode>(1));

        }

        [TestMethod]
        public void NodeType_CheckBehaviorInHashSets()
        {
            var nodeType1 = new NodeType<Node>(1);
            var nodeType2 = new NodeType<ActorNode>(2);
            var nodeType3 = new NodeType<StoryNode>(3);
            
            var hashSet = new HashSet<INodeType>(new List<INodeType> { nodeType1, nodeType2, nodeType3, nodeType1, nodeType3 });

            Assert.AreEqual(3, hashSet.Count);
            Assert.IsTrue(hashSet.Contains(nodeType1));
            Assert.IsTrue(hashSet.Contains(nodeType2));
            Assert.IsTrue(hashSet.Contains(nodeType3));
            
        }
    }
}
