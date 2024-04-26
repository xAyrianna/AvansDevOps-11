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
    public class TestedItemStateTests
    {
        private BacklogItem _item;

        public TestedItemStateTests()
        {
            _item = new BacklogItem(new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3)), new Developer("Joey Doe", "Joey Doe"), "Test item", "Test description", 6);
        }

        [Fact]
        public void StartItem_In_TestedState()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);

            // Act
            _item.ItemState.Start();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishItem_In_TestedState()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);

            // Act
            _item.ItemState.Finish();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void TestItem_In_TestedState()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);

            // Act
            _item.ItemState.Test();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void FinishTestItem_In_TestedState()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);

            // Act
            _item.ItemState.FinishTest();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void RedoItem_In_TestedState()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);

            // Act
            _item.ItemState.Redo();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void RetestItem_In_TestedState_When_Sprint_InProgress()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            _item.Sprint.State = new InProgressSprintState(_item.Sprint);

            // Act
            _item.ItemState.Retest();

            // Assert
            Assert.IsType<ReadyForTestingItemState>(_item.ItemState);
        }

        [Fact]
        public void RetestItem_In_TestedState_When_Sprint_Not_InProgress()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            _item.Sprint.State = new FinishedSprintState(_item.Sprint);

            // Act
            _item.ItemState.Retest();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_For_No_Activities_In_TestedState_When_Sprint_InProgress()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            _item.Sprint.State = new InProgressSprintState(_item.Sprint);

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_For_No_Activities_In_TestedState_When_Sprint_Not_InProgress()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            _item.Sprint.State = new FinishedSprintState(_item.Sprint);

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_For_Activities_Not_Completely_Done_In_TestedState()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            var activity1 = new Activity(_item.Developer, "Test activity 1", "Test description 1");
            var activity2 = new Activity(_item.Developer, "Test activity 2", "Test description 2");
            activity1.IsDone = true;
            _item.Activities = new List<Activity> { activity1, activity2 };


            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_For_Activities_Completely_Done_In_TestedState_When_Sprint_InProgress()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            _item.Sprint.State = new InProgressSprintState(_item.Sprint);
            var activity1 = new Activity(_item.Developer, "Test activity 1", "Test description 1");
            var activity2 = new Activity(_item.Developer, "Test activity 2", "Test description 2");
            activity1.IsDone = true;
            activity2.IsDone = true;
            _item.Activities = new List<Activity> { activity1, activity2 };

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<DoneItemState>(_item.ItemState);
        }

        [Fact]
        public void ApproveItem_For_Activities_Completely_Done_In_TestedState_When_Sprint_Not_InProgress()
        {
            // Arrange
            _item.ItemState = new TestedItemState(_item);
            _item.Sprint.State = new FinishedSprintState(_item.Sprint);
            var activity1 = new Activity(_item.Developer, "Test activity 1", "Test description 1");
            var activity2 = new Activity(_item.Developer, "Test activity 2", "Test description 2");
            activity1.IsDone = true;
            activity2.IsDone = true;
            _item.Activities = new List<Activity> { activity1, activity2 };

            // Act
            _item.ItemState.Approve();

            // Assert
            Assert.IsType<TestedItemState>(_item.ItemState);
        }
    }
}