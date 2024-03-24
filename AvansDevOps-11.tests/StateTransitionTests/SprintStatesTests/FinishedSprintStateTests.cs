using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class FinishedSprintStateTests
    {
        private Sprint _sprint;

        public FinishedSprintStateTests()
        {
            _sprint = new ReviewSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"));
        }

        [Fact]
        public void StartSprint_In_FinishedState()
        {
            // Arrange
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.Start();

            // Assert
            Assert.IsType<FinishedSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_In_FinishedState()
        {
            // Arrange
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<CanceledSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishSprint_In_FinishedState()
        {
            // Arrange
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.Finish();

            // Assert
            Assert.IsType<FinishedSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_ForReviewSprint_In_FinishedState()
        {
            // Arrange
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_ForPipelineSprint_In_FinishedState()
        {
            // Arrange
            _sprint.Pipeline = new Pipeline(_sprint);
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_ForEndingSprint_In_FinishedState()
        {
            // Arrange
            _sprint.Review = false;
            _sprint.Pipeline = null;
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_In_FinishedState()
        {
            // Arrange
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<FinishedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview_In_FinishedState()
        {
            // Arrange
            _sprint.State = new FinishedSprintState(_sprint);

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<FinishedSprintState>(_sprint.State);
        }
    }
}