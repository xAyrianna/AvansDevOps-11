using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class ClosedSprintStateTests
    {
        private Sprint _sprint;

        public ClosedSprintStateTests()
        {
            _sprint = new ReleaseSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
        }

        [Fact]
        public void StartSprint_In_ClosedState()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);

            // Act
            _sprint.State.Start();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_In_ClosedState()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishSprint_In_ClosedState()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);

            // Act
            _sprint.State.Finish();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_In_ClosedState()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_In_ClosedState()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }
    }
}