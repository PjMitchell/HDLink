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
        [ExpectedException(typeof(ArgumentNullException))]
        public void NodeType_ThrowsNullException_IfNodeTYpeNull()
        {
            var node = new NodeType(1, null);
        }

        [TestMethod]
        public void NodeType_EqualitiesWorks()
        {

            Assert.AreEqual(new NodeType(1, "one"), new NodeType(1, "one"));
            Assert.AreEqual(new NodeType(1, "one"), new NodeType(1, "two"));
            Assert.AreNotEqual(new NodeType(1, "one"), new NodeType(2, "two"));
        }

        [TestMethod]
        public void NodeType_CheckBehaviorInHashSets()
        {
            var nodeType1 = new NodeType(1, "one");
            var nodeType2 = new NodeType(2, "two");
            var nodeType3 = new NodeType(3, "three");
            
            var hashSet = new HashSet<NodeType>(new[] { nodeType1, nodeType2, nodeType3, nodeType1, nodeType3 });

            Assert.AreEqual(3, hashSet.Count);
            Assert.IsTrue(hashSet.Contains(nodeType1));
            Assert.IsTrue(hashSet.Contains(nodeType2));
            Assert.IsTrue(hashSet.Contains(nodeType3));
            
        }
    }
}
