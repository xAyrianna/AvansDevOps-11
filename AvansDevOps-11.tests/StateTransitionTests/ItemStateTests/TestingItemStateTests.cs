using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.ItemStateTests
{
    public class TestingItemStateTests
    {
        private BacklogItem _item;

        public TestingItemStateTests()
        {
            _item = new BacklogItem(new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe")), new Developer("Joey Doe", "Joey Doe"), "Test item", "Test description", 6);
        }

        [Fact]
        public void StartItem_In_TestingState()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.Start();

            // Assert
            Assert.IsType<TestingItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishItem_In_TestingState()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.Finish();

            // Assert
            Assert.IsType<TestingItemState>(_item.ItemState);
        }

        [Fact]
        public void TestItem_In_Testing()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.Test();

            // Assert
            Assert.IsType<TestingItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishTestItem_In_Testing()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.FinishTest();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void RedoItem_In_Testing()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.Redo();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void RetestItem_In_Testing()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.Retest();

            // Assert
            Assert.IsType<TestingItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_In_Testing()
        {
            // Arrange
            _item.ItemState = new TestingItemState(_item);

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<TestingItemState>(_item.ItemState);
        }
    }
}