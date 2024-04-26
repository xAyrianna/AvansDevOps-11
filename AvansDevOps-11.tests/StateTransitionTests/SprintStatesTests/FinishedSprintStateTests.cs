using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Composites.PipelineComposite;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class FinishedSprintStateTests
    {
        private Sprint _sprint;

        public FinishedSprintStateTests()
        {
            _sprint = new ReviewSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
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
        public void ApproveSprint_ForNonReleaseSprint_With_Pipeline_In_FinishedState()
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
        public void ApproveSprint_ForReleaseSprint_With_Deployment_Pipeline_In_FinishedState()
        {
            // Arrange
            Sprint releaseSprint = new ReleaseSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
            releaseSprint.State = new FinishedSprintState(releaseSprint);
            releaseSprint.Pipeline = new Pipeline(releaseSprint);
            PipelineComposite pipelineComposite = new PipelineComposite(PipelineActionType.DEPLOY);
            pipelineComposite.Add(new PipelineAction("Test run", PipelineActionType.DEPLOY));
            releaseSprint.Pipeline.AddActivity(pipelineComposite);

            // Act
            releaseSprint.State.Approve();

            // Assert
            Assert.IsType<RunningPipelineSprintState>(releaseSprint.State);
        }

        [Fact]
        public void ApproveSprint_ForReleaseSprint_Without_Deployment_Pipeline_In_FinishedState()
        {
            // Arrange
            Sprint releaseSprint = new ReleaseSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
            releaseSprint.State = new FinishedSprintState(releaseSprint);
            releaseSprint.Pipeline = new Pipeline(releaseSprint);
            PipelineComposite pipelineComposite = new PipelineComposite(PipelineActionType.TEST);
            pipelineComposite.Add(new PipelineAction("Test run", PipelineActionType.TEST));
            releaseSprint.Pipeline.AddActivity(pipelineComposite);

            // Act
            releaseSprint.State.Approve();

            // Assert
            Assert.IsType<FinishedSprintState>(releaseSprint.State);
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