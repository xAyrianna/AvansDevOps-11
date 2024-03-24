using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class InProgressSprintStateTests
    {
        private Sprint _sprint;

        public InProgressSprintStateTests()
        {
            _sprint = new ReviewSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"));
        }

        [Fact]
        public void StartSprint_In_InProgressState()
        {
            // Arrange
            _sprint.State = new InProgressSprintState(_sprint);

            // Act
            _sprint.State.Start();

            // Assert
            Assert.IsType<InProgressSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_In_InProgressState()
        {
            // Arrange
            _sprint.State = new InProgressSprintState(_sprint);

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<InProgressSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishSprint_In_InProgressState()
        {
            // Arrange
            _sprint.State = new InProgressSprintState(_sprint);

            // Act
            _sprint.State.Finish();

            // Assert
            Assert.IsType<FinishedSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_In_InProgressState()
        {
            // Arrange
            _sprint.State = new InProgressSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<InProgressSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_In_InProgressState()
        {
            // Arrange
            _sprint.State = new InProgressSprintState(_sprint);

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<InProgressSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview_In_InProgressState()
        {
            // Arrange
            _sprint.State = new InProgressSprintState(_sprint);

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<InProgressSprintState>(_sprint.State);
        }
    }
}