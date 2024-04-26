using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.ItemStateTests
{
    public class DoneItemStateTests
    {
        private BacklogItem _item;

        public DoneItemStateTests()
        {
            _item = new BacklogItem(new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3)), new Developer("Joey Doe", "Joey Doe"), "Test item", "Test description", 6);
        }

        [Fact]
        public void StartItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Start();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Finish();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void TestItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Test();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishTestItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Test();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void RedoItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Redo();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void RetestItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Retest();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_In_DoneState()
        {
            // Arrange
            _item.ItemState = new DoneItemState(_item);

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void Threads_Close_When_Item_Is_Done()
        {
            // Arrange
            _item.CreateThread(new Developer("Joey Doe", "Joey Doe"), "Test thread");
            _item.ItemState = new DoneItemState(_item);
            // Act

            // Assert
            foreach (var thread in _item.Threads)
            {
                Assert.True(thread.Value.IsClosed);
            }
        }

        [Fact]
        public void Threads_ReOpen_When_Item_Is_Redone()
        {
            // Arrange
            _item.CreateThread(new Developer("Joey Doe", "Joey Doe"), "Test thread");
            _item.ItemState = new DoneItemState(_item);
            _item.ItemState.Redo();
            // Act

            // Assert
            foreach (var thread in _item.Threads)
            {
                Assert.False(thread.Value.IsClosed);
            }
        }
    }
}