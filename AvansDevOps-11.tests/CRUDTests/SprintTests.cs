using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Adapters.NotificationAdapter;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class SprintTests
    {
        private Project project = new Project("TestProject", new ProductOwner("John Doe", "John Doe"));
        private ScrumMaster scrumMaster = new ScrumMaster("Jane Doe", "Jane Doe");
        private DateTime time = new DateTime(2024, 1, 1);

        [Fact]
        public void Assert_ReviewSprint_Needs_Review()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);

            // Act

            // Assert
            Assert.True(sprint.Review);
        }

        [Fact]
        public void Assert_ReleaseSprint_Has_Pipeline()
        {
            // Arrange
            var sprint = new ReleaseSprint(project, scrumMaster);

            // Act

            // Assert
            Assert.NotNull(sprint.Pipeline);
        }

        [Fact]
        public void Assert_Sprint_Has_NotificationEvent()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);

            // Act

            // Assert
            Assert.NotNull(sprint.NotificationEvent);
        }

        [Fact]
        public void Assert_Sprint_Has_Notification_Subscription()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);

            // Act

            // Assert
            Assert.Single(sprint.NotificationEvent.Subscribers);
        }

        [Fact]
        public void Assert_Adding_NotificationStrategy()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            var SMSAdapter = new SMSAdapter();

            // Act
            sprint.AddNotificationStrategy(SMSAdapter);

            // Assert
            Assert.Equal(2, sprint.NotificationEvent.Subscribers.Count);
        }

        [Fact]
        public void Assert_Removing_NotificationStrategy()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            var SMSAdapter = new SMSAdapter();
            sprint.AddNotificationStrategy(SMSAdapter);

            // Act
            sprint.RemoveNotificationStrategy(SMSAdapter);

            // Assert
            Assert.Single(sprint.NotificationEvent.Subscribers);
        }

        [Fact]
        public void Assert_Sprint_Is_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);

            // Act

            // Assert
            Assert.IsType<CreatedSprintState>(sprint.State);
        }

        [Fact]
        public void Assert_Sprint_Name_Can_Be_Changed_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new CreatedSprintState(sprint);

            // Act
            sprint.Name = "Test";

            // Assert
            Assert.Equal("Test", sprint.Name);
        }

        [Fact]
        public void Assert_Sprint_Name_Cannot_Be_Changed_When_Not_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new InProgressSprintState(sprint);

            // Act
            sprint.Name = "Test";

            // Assert
            Assert.NotEqual("Test", sprint.Name);
        }
        
        [Fact]
        public void Assert_Sprint_StartDate_Can_Be_Changed_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster)
            {
                // Act
                StartDate = time
            };

            // Assert
            Assert.Equal(time, sprint.StartDate);
        }
        
        [Fact]
        public void Assert_Sprint_StartDate_Cannot_Be_Changed_When_Not_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State.Start();

            // Act
            sprint.StartDate = time;

            // Assert
            Assert.NotEqual(time, sprint.StartDate);
        }

        [Fact]
        public void Assert_Sprint_EndDate_Can_Be_Changed_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);

            // Act
            sprint.EndDate = time;

            // Assert
            Assert.Equal(time, sprint.EndDate);
        }

        [Fact]
        public void Assert_Sprint_EndDate_Cannot_Be_Changed_When_Not_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new InProgressSprintState(sprint);

            // Act
            sprint.EndDate = time;

            // Assert
            Assert.NotEqual(time, sprint.EndDate);
        }

        [Fact]
        public void Assert_Sprint_Can_Add_Developer()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            var developer = new Developer("Joey Doe", "Joey Doe");

            // Act
            sprint.AddDeveloper(developer);

            // Assert
            Assert.Single(sprint.Developers);
        }

        [Fact]
        public void Assert_Sprint_Can_Remove_Developer()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            var developer = new Developer("Joey Doe", "Joey Doe");
            sprint.Developers.Add(developer);

            // Act
            sprint.RemoveDeveloper(developer);

            // Assert
            Assert.Empty(sprint.Developers);
        }

        [Fact]
        public void Assert_Sprint_Can_Add_Tester()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            var tester = new Tester("Joey Doe", "Joey Doe");

            // Act
            sprint.AddTester(tester);

            // Assert
            Assert.Single(sprint.Testers);
        }

        [Fact]
        public void Assert_Sprint_Can_Remove_Tester()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            var tester = new Tester("Joey Doe", "Joey Doe");
            sprint.Testers.Add(tester);

            // Act
            sprint.RemoveTester(tester);

            // Assert
            Assert.Empty(sprint.Testers);
        }

        [Fact]
        public void Assert_Uploading_ReviewSummary_Changes_State_When_Review_Needed_And_Sprint_InReview()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new InReviewSprintState(sprint);

            // Act
            sprint.UploadReviewSummary();

            // Assert
            Assert.NotNull(sprint.ReviewSummary);
            Assert.IsType<ClosedSprintState>(sprint.State);
        }

        [Fact]
        public void Assert_Uploading_ReviewSummary_Does_Not_Change_State_When_Review_Needed_And_Sprint_Not_InReview()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new CreatedSprintState(sprint);

            // Act
            sprint.UploadReviewSummary();

            // Assert
            Assert.Null(sprint.ReviewSummary);
            Assert.IsType<CreatedSprintState>(sprint.State);
        }

        [Fact]
        public void Assert_Sprint_Can_Add_BacklogItem_When_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new CreatedSprintState(sprint);
            var backlogItem = new BacklogItem(sprint,new Developer("Joey Doe", "Joey Doe"), "Test", "Test", 6);

            // Act
            sprint.AddBacklogItem(backlogItem);

            // Assert
            Assert.Single(sprint.BacklogItems);
        }

        [Fact]
        public void Assert_Sprint_Cannot_Add_BacklogItem_When_Not_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new InProgressSprintState(sprint);
            var backlogItem = new BacklogItem(sprint, new Developer("Joey Doe", "Joey Doe"), "Test", "Test", 6);

            // Act
            sprint.AddBacklogItem(backlogItem);

            // Assert
            Assert.Empty(sprint.BacklogItems);
        }

        [Fact]
        public void Assert_Sprint_Can_Remove_BacklogItem_When_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new CreatedSprintState(sprint);
            var backlogItem = new BacklogItem(sprint, new Developer("Joey Doe", "Joey Doe"), "Test", "Test", 6);
            sprint.BacklogItems.Add(backlogItem);

            // Act
            sprint.RemoveBacklogItem(backlogItem);

            // Assert
            Assert.Empty(sprint.BacklogItems);
        }

        [Fact]
        public void Assert_Sprint_Cannot_Remove_BacklogItem_When_Not_In_CreatedState()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new InProgressSprintState(sprint);
            var backlogItem = new BacklogItem(sprint, new Developer("Joey Doe", "Joey Doe"), "Test", "Test", 6);
            sprint.BacklogItems.Add(backlogItem);

            // Act
            sprint.RemoveBacklogItem(backlogItem);

            // Assert
            Assert.Single(sprint.BacklogItems);
        }

        [Fact]
        public void Assert_Sprint_Can_Get_Total_StoryPoints()
        {
            // Arrange
            var sprint = new ReviewSprint(project, scrumMaster);
            sprint.State = new CreatedSprintState(sprint);
            var backlogItem = new BacklogItem(sprint, new Developer("Joey Doe", "Joey Doe"), "Test", "Test", 6);
            var backlogItem2 = new BacklogItem(sprint, new Developer("Joey Doe", "Joey Doe"), "Test", "Test", 4);
            sprint.BacklogItems.Add(backlogItem);
            sprint.BacklogItems.Add(backlogItem2);

            // Act
            var totalStoryPoints = sprint.GetTotalStoryPoints();

            // Assert
            Assert.Equal(10, totalStoryPoints);
        }
    }
}