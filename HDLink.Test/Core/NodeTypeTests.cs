using System.Collections.Generic;
using HDLink.Test.Mocks;
using Xunit;

namespace HDLink.Test.Core
{

    public class NodeTypeTest
    {

        [Fact]
        public void NodeType_EqualitiesWorks()
        {
            Assert.Equal(new NodeType<Node>(1), new NodeType<Node>(1));
            Assert.NotEqual(new NodeType<Node>(1), new NodeType<Node>(2));
            Assert.NotEqual((object)new NodeType<ActorNode>(1), (object)new NodeType<StoryNode>(1));
        }

        [Fact]
        public void NodeType_CheckBehaviorInHashSets()
        {
            var nodeType1 = new NodeType<Node>(1);
            var nodeType2 = new NodeType<ActorNode>(2);
            var nodeType3 = new NodeType<StoryNode>(3);
            
            var hashSet = new HashSet<INodeType>(new List<INodeType> { nodeType1, nodeType2, nodeType3, nodeType1, nodeType3 });

            Assert.Equal(3, hashSet.Count);
            Assert.True(hashSet.Contains(nodeType1));
            Assert.True(hashSet.Contains(nodeType2));
            Assert.True(hashSet.Contains(nodeType3));
            
        }
    }
}
