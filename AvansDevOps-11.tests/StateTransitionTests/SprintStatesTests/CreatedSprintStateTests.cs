using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class CreatedSprintStateTests
    {
        private Sprint _sprint;

        public CreatedSprintStateTests()
        {
            _sprint = new ReviewSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
        }

        [Fact]
        public void StartSprint_In_CreatedState()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);

            // Act
            _sprint.State.Start();

            // Assert
            Assert.IsType<InProgressSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_In_CreatedState()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<CreatedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishSprint_In_CreatedState()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);

            // Act
            _sprint.State.Finish();

            // Assert
            Assert.IsType<CreatedSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveState_In_CreatedState()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<CreatedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_In_CreatedState()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<CreatedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview_In_CreatedState()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<CreatedSprintState>(_sprint.State);
        }
    }
}