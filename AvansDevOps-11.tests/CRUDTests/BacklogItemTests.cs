using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class BacklogItemTests
    {
        private Developer developer = new Developer("Joe Doe", "Joe Doe");
        private Sprint sprint = new ReviewSprint(new Project("TestProject", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
        
        [Fact]
        public void Assert_Item_Is_In_ToDoItemState()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);

            // Act
            var itemState = backlogItem.ItemState;

            // Assert
            Assert.IsType<ToDoItemState>(itemState);
        }

        [Fact]
        public void Assert_Item_Can_Add_Activity_When_Sprint_In_CreatedState()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);
            var activity = new Activity(developer, "Test", "Test");
            sprint.State = new CreatedSprintState(sprint);
            // Act
            backlogItem.AddActivity(activity);

            // Assert
            Assert.Contains(activity, backlogItem.Activities);
        }

        [Fact]
        public void Assert_Item_Cannot_Add_Activity_When_Sprint_Not_In_CreatedState()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);
            var activity = new Activity(developer, "Test", "Test");
            sprint.State = new InProgressSprintState(sprint);

            // Act
            backlogItem.AddActivity(activity);

            // Assert
            Assert.DoesNotContain(activity, backlogItem.Activities);
        }

        [Fact]
        public void Assert_Item_Can_Remove_Activity_When_Sprint_In_CreatedState()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);
            var activity = new Activity(developer, "Test", "Test");
            sprint.State = new CreatedSprintState(sprint);

            // Act
            backlogItem.AddActivity(activity);
            backlogItem.RemoveActivity(activity);

            // Assert
            Assert.DoesNotContain(activity, backlogItem.Activities);
        }

        [Fact]
        public void Assert_Item_Cannot_Remove_Activity_When_Sprint_Not_In_CreatedState()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);
            var activity = new Activity(developer, "Test", "Test");
            sprint.State = new InProgressSprintState(sprint);

            // Act
            backlogItem.AddActivity(activity);
            backlogItem.RemoveActivity(activity);

            // Assert
            Assert.Contains(activity, backlogItem.Activities);
        }

        [Fact]
        public void Assert_Item_Can_Create_Thread()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);
            

            // Act
            backlogItem.CreateThread(developer, "Test");

            // Assert
            Assert.True(backlogItem.Threads.Any());
        }

        [Fact]
        public void Assert_Thread_Can_Be_Deleted_By_Subject()
        {
            // Arrange
            var backlogItem = new BacklogItem(sprint, developer, "Test", "Test", 5);
            backlogItem.CreateThread(developer, "Test");

            // Act
            backlogItem.Threads.Remove("Test");

            // Assert
            Assert.False(backlogItem.Threads.Any());
        }
    }
}