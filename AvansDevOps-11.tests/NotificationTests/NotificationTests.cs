using AvansDevOps_11.Adapters.NotificationAdapter;
using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.States.PipelineStates;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.tests.NotificationTests
{
    public class NotificationTests
    {
        [Fact]
        public void Assert_NotificationEvent_Is_Created_For_Sprint()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));

            // Act

            // Assert
            Assert.NotNull(sprint.NotificationEvent);
            Assert.NotEmpty(sprint.NotificationEvent.Subscribers);
        }

        [Fact]
        public void Assert_NotificationEvent_Can_Add_Strategy()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            INotificationAdapter strategy = new EmailAdapter();

            // Act
            sprint.AddNotificationStrategy(strategy);

            // Assert
            Assert.Contains(strategy, sprint.NotificationEvent.Subscribers);
        }

        [Fact]
        public void Assert_NotificationEvent_Can_Remove_Strategy()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            INotificationAdapter strategy = new EmailAdapter();
            sprint.AddNotificationStrategy(strategy);

            // Act
            sprint.RemoveNotificationStrategy(strategy);

            // Assert
            Assert.DoesNotContain(strategy, sprint.NotificationEvent.Subscribers);
        }

        [Fact]
        public void Assert_NotificationEvent_Can_Send_Notification()
        {
            ProductOwner productOwner = new ProductOwner("John Doe", "John Doe");
            ScrumMaster scrumMaster = new ScrumMaster("Jane Doe", "Jane Doe");
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", productOwner), scrumMaster);
            var mockStrategy = new Mock<INotificationAdapter>();
            sprint.AddNotificationStrategy(mockStrategy.Object);
            
            List<User> usersToBeNotified = new List<User> { productOwner, scrumMaster };

            // Act
            sprint.NotificationEvent.Notify(usersToBeNotified, "Notification text", "Notification subject");

            // Assert
            mockStrategy.Verify(x => x.SendNotification(usersToBeNotified, It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void Assert_Notification_Sent_When_Sprint_Is_Canceled()
        {
            // Arrange
            Sprint sprint = new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Developer developer = new Developer("Joey Doe", "Joey Doe");

            var mockStrategy = new Mock<INotificationAdapter>();
            sprint.AddNotificationStrategy(mockStrategy.Object);

            List<User> toBeNotified = new List<User> { sprint.ScrumMaster, sprint.Project.ProductOwner };

            // Act
            sprint.State = new CanceledSprintState(sprint, "Test");

            // Assert
            mockStrategy.Verify(x => x.SendNotification(toBeNotified, It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void Assert_Notification_Sent_When_Sprint_Is_Closed()
        {
            // Arrange
            Sprint sprint = new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Developer developer = new Developer("Joey Doe", "Joey Doe");

            var mockStrategy = new Mock<INotificationAdapter>();
            sprint.AddNotificationStrategy(mockStrategy.Object);

            List<User> toBeNotified = new List<User> { sprint.ScrumMaster, sprint.Project.ProductOwner };

            // Act
            sprint.State = new ClosedSprintState(sprint);

            // Assert
            mockStrategy.Verify(x => x.SendNotification(toBeNotified, It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void Assert_Notifcation_Sent_When_Pipeline_Has_An_Error()
        {
            // Arrange
            Sprint sprint = new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Developer developer = new Developer("Joey Doe", "Joey Doe");

            var mockStrategy = new Mock<INotificationAdapter>();
            sprint.AddNotificationStrategy(mockStrategy.Object);

            sprint.Pipeline = new Pipeline(sprint);

            List<User> toBeNotified = new List<User> { sprint.ScrumMaster };

            // Act
            sprint.Pipeline.State = new PipelineErrorState(sprint.Pipeline);

            // Assert
            mockStrategy.Verify(x => x.SendNotification(toBeNotified, It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void Assert_Notification_Sent_When_BacklogItem_Ready_For_Testing()
        {
            // Arrange
            Sprint sprint = new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            sprint.AddTester(new Tester("Jay Doe", "Jay Doe"));
            sprint.AddTester(new Tester("Jill Doe", "Jill Doe"));   
            Developer developer = new Developer("Joey Doe", "Joey Doe");
            sprint.AddDeveloper(developer);

            var mockStrategy = new Mock<INotificationAdapter>();
            sprint.AddNotificationStrategy(mockStrategy.Object);
            BacklogItem backlogItem = new BacklogItem(sprint, developer, "Test item", "Test description", 6);

            // Act
            backlogItem.ItemState = new ReadyForTestingItemState(backlogItem);

            // Assert
            mockStrategy.Verify(x => x.SendNotification(sprint.Testers.Cast<User>().ToList(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void Assert_Notification_Sent_When_BacklogItem_Moves_Back_To_ToDo()
        {
            // Arrange
            Sprint sprint = new ReviewSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Developer developer = new Developer("Joey Doe", "Joey Doe");

            var mockStrategy = new Mock<INotificationAdapter>();
            sprint.AddNotificationStrategy(mockStrategy.Object);
            BacklogItem backlogItem = new BacklogItem(sprint, developer, "Test item", "Test description", 6);

            List<User> toBeNotified = new List<User> { sprint.ScrumMaster };

            backlogItem.ItemState = new TestingItemState(backlogItem);

            // Act
            backlogItem.ItemState.Redo();

            // Assert
            mockStrategy.Verify(x => x.SendNotification(toBeNotified, It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
