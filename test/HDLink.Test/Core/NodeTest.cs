using System;
using System.Collections.Generic;
using HDLink.Test.Mocks;
using Xunit;

namespace HDLink.Test.Core
{

    public class NodeTest
    {
        [Fact]
        public void Node_ThrowsNullException_IfNodeTYpeNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new Node(1, null));
        }

        [Fact]
        public void Node_EqualitiesWorks()
        {

            Assert.Equal(new Node(1, MockNodeTypes.Actor), new Node(1, MockNodeTypes.Actor));
            Assert.NotEqual(new Node(2, MockNodeTypes.Actor), new Node(1, MockNodeTypes.Actor));
            Assert.NotEqual(new Node(2, MockNodeTypes.Actor), new Node(2, MockNodeTypes.Story));
        }

        [Fact]
        public void Node_CheckBehaviorInHashSets()
        {
            var node1 = new Node(1, MockNodeTypes.Story);
            var node2 = new Node(2, MockNodeTypes.Actor);
            var node3 = new Node(1, MockNodeTypes.Actor);
            var node4 = new Node(3, MockNodeTypes.Story);

            var hashSet = new HashSet<Node>(new[] { node1, node2, node3, node1, node3 });

            Assert.Equal(3, hashSet.Count);
            Assert.True(hashSet.Contains(node1));
            Assert.True(hashSet.Contains(node2));
            Assert.True(hashSet.Contains(node3));
            Assert.False(hashSet.Contains(node4));

        }
    }
}
