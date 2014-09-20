using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using HDLink.Test.Mocks;


namespace HDLink.Test
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
            
            Assert.AreEqual(new Node(1, new MockNodeType{Id =2}), new Node(1, new MockNodeType{Id =2}));
            Assert.AreNotEqual(new Node(2, new MockNodeType { Id = 2 }), new Node(1, new MockNodeType { Id = 2 }));
            Assert.AreNotEqual(new Node(2, new MockNodeType { Id = 2 }), new Node(2, new MockNodeType { Id =1 }));
        }

        [TestMethod]
        public void Node_CheckBehaviorInHashSets()
        {
            var node1 = new Node(1, new MockNodeType { Id = 2 });
            var node2 = new Node(2, new MockNodeType { Id = 1 });
            var node3 = new Node(1, new MockNodeType { Id = 1 });
            var node4 = new Node(2, new MockNodeType { Id = 2 });

            var hashSet = new HashSet<Node>(new[] { node1, node2, node3, node1, node3 });

            Assert.AreEqual(3, hashSet.Count);
            Assert.IsTrue(hashSet.Contains(node1));
            Assert.IsTrue(hashSet.Contains(node2));
            Assert.IsTrue(hashSet.Contains(node3));
            Assert.IsFalse(hashSet.Contains(node4));

        }
    }
}
