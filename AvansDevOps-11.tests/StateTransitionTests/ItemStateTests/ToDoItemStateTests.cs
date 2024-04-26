using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.ItemStateTests
{
    public class ToDoItemStateTests
    {
        private BacklogItem _item;

        public ToDoItemStateTests()
        {
            _item = new BacklogItem(new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3)), new Developer("Joey Doe", "Joey Doe"), "Test item", "Test description", 6);
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void StartItem_In_ToDoState_When_Sprint_InProgress()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);
            _item.Sprint.State = new InProgressSprintState(_item.Sprint);

            // Act
            _item.ItemState.Start();

            // Assert
            Assert.IsType<DoingItemState>(_item.ItemState);
        }

        [Fact]
        public void StartItem_In_ToDoState_When_Sprint_Not_InProgress()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);
            _item.Sprint.State = new FinishedSprintState(_item.Sprint);

            // Act
            _item.ItemState.Start();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishItem_In_ToDoState()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);

            // Act
            _item.ItemState.Finish();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void TestItem_In_ToDo()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);

            // Act
            _item.ItemState.Test();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishTestItem_In_ToDoState()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);

            // Act
            _item.ItemState.FinishTest();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void RedoItem_In_ToDoState()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);

            // Act
            _item.ItemState.Redo();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void RetestItem_In_ToDoState()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);

            // Act
            _item.ItemState.Retest();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_In_ToDoState()
        {
            // Arrange
            _item.ItemState = new ToDoItemState(_item);

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<ToDoItemState>(_item.ItemState);
        }
    }
}