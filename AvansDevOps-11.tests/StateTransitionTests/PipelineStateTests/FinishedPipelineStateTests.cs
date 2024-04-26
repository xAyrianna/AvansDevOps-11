using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.States.PipelineStates;
using AvansDevOps_11.Users;
using Xunit;

namespace AvansDevOps_11.tests.StateTransitionTests.PipelineStateTests
{
    public class FinishedPipelineStateTests
    {
        private Pipeline _pipeline;

        public FinishedPipelineStateTests()
        {
            _pipeline = new Pipeline(new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3)));
        }

        [Fact]
        public void StartPipeline_In_FinishedState()
        {
            // Arrange
            _pipeline.State = new FinishedPipelineState(_pipeline);

            // Act
            _pipeline.State.Start();

            // Assert
            Assert.IsType<FinishedPipelineState>(_pipeline.State);
        }

        [Fact]
        public void FinishPipeline_In_FinishedState()
        {
            // Arrange
            _pipeline.State = new FinishedPipelineState(_pipeline);

            // Act
            _pipeline.State.Finish();

            // Assert
            Assert.IsType<FinishedPipelineState>(_pipeline.State);
        }

        [Fact]
        public void CallError_In_FinishedState()
        {
            // Arrange
            _pipeline.State = new FinishedPipelineState(_pipeline);

            // Act
            _pipeline.State.Error();

            // Assert
            Assert.IsType<FinishedPipelineState>(_pipeline.State);
        }

        [Fact]
        public void RestartPipeline_In_FinishedState()
        {
            // Arrange
            _pipeline.State = new FinishedPipelineState(_pipeline);

            // Act
            _pipeline.State.Restart();

            // Assert
            Assert.IsType<FinishedPipelineState>(_pipeline.State);
        }
    }
}