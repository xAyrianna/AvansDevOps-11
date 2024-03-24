using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.ItemStateTests
{
    public class ReadyForTestingItemStateTests
    {
        private BacklogItem _item;

        public ReadyForTestingItemStateTests()
        {
            _item = new BacklogItem(new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe")), new Developer("Joey Doe", "Joey Doe"), "Test item", "Test description", 6);
        }

        [Fact]
        public void StartItem_In_ReadyForTestingState()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.Start();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishItem_In_ReadyForTestingState()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.Finish();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }

        [Fact]
        public void TestItem_In_ReadyForTesting()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.Test();

            // Assert
            Assert.IsType<TestingItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishTestItem_In_ReadyForTesting()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.FinishTest();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }

        [Fact]
        public void RedoItem_In_ReadyForTesting()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.Redo();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }

        [Fact]
        public void RetestItem_In_ReadyForTesting()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.Retest();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_In_ReadyForTesting()
        {
            // Arrange
            _item.ItemState = new ReadyForTestingItemState(_item);

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }
    }
}