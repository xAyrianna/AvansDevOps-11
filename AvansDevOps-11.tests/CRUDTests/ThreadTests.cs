using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class ThreadTests
    {
        private Developer _developer = new Developer("John Doe", "John Doe");
        private BacklogItem _backlogItem = new BacklogItem(new ReviewSprint(new Project("Test project", new ProductOwner("Jane Doe", "Jane Doe")), new ScrumMaster("Jane Doe", "Jane Doe")), new Developer("Joey Doe", "Joey Doe"), "Test item", "Test description", 6);

        [Fact]
        public void Assert_ThreadOwner_Gets_Added_To_UsersInThread_When_Creating_Thread()
        {
            // Arrange
            Thread thread = new Thread(_backlogItem, _developer, "Test subject", "Test description");

            // Act


            // Assert
            Assert.Contains(_developer, thread.UsersInThread);
        }

        [Fact]
        public void Assert_User_Gets_Added_To_UsersInThread_When_Creating_Thread()
        {
            // Arrange
            Thread thread = new Thread(_backlogItem, _developer, "Test subject", "Test description");
            Developer reactioner = new Developer("Jay Doe", "Jay Doe");

            // Act
            thread.AddReaction(new ThreadReaction(reactioner, "Test reaction"));

            // Assert
            Assert.Contains(reactioner, thread.UsersInThread);
        }

        [Fact]
        public void Assert_Adding_Reaction_To_Thread_When_Thread_Is_Open()
        {
            // Arrange
            Thread thread = new Thread(_backlogItem, _developer, "Test subject", "Test description");
            ThreadReaction reaction = new ThreadReaction(_developer, "Test reaction");

            // Act
            thread.AddReaction(reaction);

            // Assert
            Assert.Contains(reaction, thread.Reactions);
        }

        [Fact]
        public void Assert_Not_Adding_Reaction_To_Thread_When_Thread_Is_Closed()
        {
            // Arrange
            Thread thread = new Thread(_backlogItem, _developer, "Test subject", "Test description");
            ThreadReaction reaction = new ThreadReaction(_developer, "Test reaction");

            // Act
            thread.IsClosed = true;
            thread.AddReaction(reaction);

            // Assert
            Assert.DoesNotContain(reaction, thread.Reactions);
        }
    }
}