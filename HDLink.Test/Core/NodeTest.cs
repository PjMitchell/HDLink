using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HDLink.Test.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HDLink.Test.Core
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void Node_ThrowsNullException_IfNodeTYpeNull()
        {
            var exception = false;
            try
            {
                var node = new Node(1, null);
            }
            catch(ArgumentNullException e)
            {
                exception = true;
            }

            Assert.IsTrue(exception);

        }

        [TestMethod]
        public void Node_EqualitiesWorks()
        {

            Assert.AreEqual(new Node(1, MockNodeType.Actor), new Node(1, MockNodeType.Actor));
            Assert.AreNotEqual(new Node(2, MockNodeType.Actor), new Node(1, MockNodeType.Actor));
            Assert.AreNotEqual(new Node(2, MockNodeType.Actor), new Node(2, MockNodeType.Story));
        }

        [TestMethod]
        public void Node_CheckBehaviorInHashSets()
        {
            var node1 = new Node(1, MockNodeType.Story);
            var node2 = new Node(2, MockNodeType.Actor);
            var node3 = new Node(1, MockNodeType.Actor);
            var node4 = new Node(3, MockNodeType.Story);

            var hashSet = new HashSet<Node>(new[] { node1, node2, node3, node1, node3 });

            Assert.AreEqual(3, hashSet.Count);
            Assert.IsTrue(hashSet.Contains(node1));
            Assert.IsTrue(hashSet.Contains(node2));
            Assert.IsTrue(hashSet.Contains(node3));
            Assert.IsFalse(hashSet.Contains(node4));

        }
    }
}
