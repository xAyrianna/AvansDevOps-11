using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.PipelineStates;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class RunningPipelineSprintStateTests
    {
        private Sprint _sprint;

        public RunningPipelineSprintStateTests()
        {
            _sprint = new ReleaseSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
        }

        [Fact]
        public void StartSprint_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);

            // Act
            _sprint.State.Start();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_ForPipelineErrorAndReview_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);
            _sprint.Pipeline!.State = new PipelineErrorState(_sprint.Pipeline);
            _sprint.Review = true;

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_ForPipelineError_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);
            _sprint.Pipeline!.State = new PipelineErrorState(_sprint.Pipeline);
            _sprint.Review = false;

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<CanceledSprintState>(_sprint.State);
        }


        [Fact]
        public void CancelSprint_ForNoPipelineError_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishSprint_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);

            // Act
            _sprint.State.Finish();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_ForFinishedPipelineAndReview_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);
            _sprint.Pipeline!.State = new FinishedPipelineState(_sprint.Pipeline);
            _sprint.Review = true;

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_ForFinishedPipeline_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);
            _sprint.Pipeline!.State = new FinishedPipelineState(_sprint.Pipeline);
            _sprint.Review = false;

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_ForNotFinishedPipeline_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);
            _sprint.Pipeline!.State = new RunningPipelineState(_sprint.Pipeline);

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview_In_RunningPipelineState()
        {
            // Arrange
            _sprint.State = new RunningPipelineSprintState(_sprint);

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(_sprint.State);
        }
    }
}