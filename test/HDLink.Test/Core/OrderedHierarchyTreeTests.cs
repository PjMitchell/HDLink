using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HDLink.Test.Core
{

    public class OrderedHierarchyTreeTests
    {
        [Fact]
        public void CanGetHierarchicalLevel()
        {
            var tree = new OrderedHierarchicalTree<TestHiearchicalElement>(GetTestElements());
            var expectedOne = new List<int> { 1, 2 };
            var expectedTwo = new List<int> { 3, 4, 5, 6, 7, 8 };


            var levelOne = tree.GetHierarchicalLevel(1).Select(s => s.Id).ToList();
            var levelTwo = tree.GetHierarchicalLevel(2).Select(s=> s.Id).ToList();
            Assert.Equal(expectedOne, levelOne);
            Assert.Equal(expectedTwo, levelTwo);


        }

        [Fact]
        public void CanGetHierarchicalLevelInOrder()
        {
            var tree = new OrderedHierarchicalTree<TestHiearchicalElement>(new List<TestHiearchicalElement>
                { 
                new TestHiearchicalElement { Id = 1, HierarchyLevel = 1, Order = 2, ParentHierarchyElementId = -1},
                new TestHiearchicalElement { Id = 2, HierarchyLevel = 1, Order = 1, ParentHierarchyElementId = -1}
                });
            var expectedOne = new List<int> { 2, 1 };

            var levelOne = tree.GetHierarchicalLevel(1).Select(s => s.Id).ToList();
            Assert.Equal(expectedOne, levelOne);
        }

        public IEnumerable<TestHiearchicalElement> GetTestElements()
        {
            return new List<TestHiearchicalElement>
            {
                new TestHiearchicalElement { Id = 1, HierarchyLevel = 1, Order = 1, ParentHierarchyElementId = -1},
                new TestHiearchicalElement { Id = 2, HierarchyLevel = 1, Order = 2, ParentHierarchyElementId = -1},
                new TestHiearchicalElement { Id = 3, HierarchyLevel = 2, Order = 1, ParentHierarchyElementId = 1},
                new TestHiearchicalElement { Id = 4, HierarchyLevel = 2, Order = 2, ParentHierarchyElementId = 1},
                new TestHiearchicalElement { Id = 5, HierarchyLevel = 2, Order = 3, ParentHierarchyElementId = 1},
                new TestHiearchicalElement { Id = 6, HierarchyLevel = 2, Order = 4, ParentHierarchyElementId = 2},
                new TestHiearchicalElement { Id = 7, HierarchyLevel = 2, Order = 5, ParentHierarchyElementId = 2},
                new TestHiearchicalElement { Id = 8, HierarchyLevel = 2, Order = 6, ParentHierarchyElementId = 2},

            };
        }
    }

    public class TestHiearchicalElement : IOrderedHierarchyElement
    {

        public int Id {get; set;}
        public int ParentHierarchyElementId {get; set;}
        public int Order {get; set;}
        public int HierarchyLevel { get; set; }
        
    }
}
