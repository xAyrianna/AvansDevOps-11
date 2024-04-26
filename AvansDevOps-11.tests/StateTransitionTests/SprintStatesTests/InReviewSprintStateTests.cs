using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AvansDevOps_11.States.SprintStates;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.SprintStatesTests
{
    public class InReviewSprintStateTests
    {
        private Sprint _sprint;

        public InReviewSprintStateTests()
        {
            _sprint = new ReviewSprint(new Project("Test project", new Users.ProductOwner("John Doe", "John Doe")), new Users.ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
        }

        [Fact]
        public void StartSprint_In_InReviewState()
        {
            // Arrange
            _sprint.State = new InReviewSprintState(_sprint);

            // Act
            _sprint.State.Start();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void CancelSprint_In_InReviewState()
        {
            // Arrange
            _sprint.State = new InReviewSprintState(_sprint);

            // Act
            _sprint.State.Cancel();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishSprint_In_InReviewState()
        {
            // Arrange
            _sprint.State = new InReviewSprintState(_sprint);

            // Act
            _sprint.State.Finish();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void ApproveSprint_In_InReviewState()
        {
            // Arrange
            _sprint.State = new InReviewSprintState(_sprint);

            // Act
            _sprint.State.Approve();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishPipeline_In_InReviewState()
        {
            // Arrange
            _sprint.State = new InReviewSprintState(_sprint);

            // Act
            _sprint.State.FinishPipeline();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview_ForUploadedDocument_In_InReviewState()
        {
            // Arrange
            _sprint.ReviewSummary = new Document();

            _sprint.State = new InReviewSprintState(_sprint);

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<ClosedSprintState>(_sprint.State);
        }

        [Fact]
        public void FinishReview_ForNoReviewSummary_In_InReviewState()
        {
            // Arrange
            _sprint.State = new InReviewSprintState(_sprint);
            _sprint.ReviewSummary = null;

            // Act
            _sprint.State.FinishReview();

            // Assert
            Assert.IsType<InReviewSprintState>(_sprint.State);
        }
    }
}