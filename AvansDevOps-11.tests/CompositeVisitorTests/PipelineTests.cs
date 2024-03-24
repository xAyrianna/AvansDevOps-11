using AvansDevOps_11.Adapters.NotificationAdapter;
using AvansDevOps_11.Composites.PipelineComposite;
using AvansDevOps_11.Users;
using AvansDevOps_11.Visitors;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.tests.CompositeVisitorTests
{
    public class PipelineTests
    {
        [Fact]
        public void Assert_PipelineActivity_Can_Be_Added()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Pipeline pipeline = new Pipeline(sprint);

            // Act
            pipeline.AddActivity(new PipelineComposite(PipelineActionType.SOURCE));

            // Assert
            Assert.NotEmpty(pipeline.Activities);
        }

        [Fact]
        public void Assert_PipelineActivity_Can_Be_Removed()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Pipeline pipeline = new Pipeline(sprint);
            PipelineComposite pipelineActivity = new PipelineComposite(PipelineActionType.SOURCE);
            pipeline.AddActivity(pipelineActivity);

            // Act
            pipeline.RemoveActivity(pipelineActivity);

            // Assert
            Assert.Empty(pipeline.Activities);
        }

        [Fact]
        public void Assert_Pipeline_Is_Executed_When_Starting_Pipeline()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Pipeline pipeline = new Pipeline(sprint);
            var mockActivity = new Mock<PipelineActivity>(PipelineActionType.UTILITY);
            var mockAction = new Mock<PipelineAction>("test", PipelineActionType.UTILITY);
            pipeline.AddActivity(mockActivity.Object);
            pipeline.AddActivity(mockAction.Object);

            // Act
            pipeline.State.Start();

            // Assert
            mockActivity.Verify(x => x.Accept(It.IsAny<ExecutePipelineVisitor>()), Times.Once);
            mockAction.Verify(x => x.Accept(It.IsAny<ExecutePipelineVisitor>()), Times.Once);
        }

        [Fact]
        public void Assert_Children_In_Pipeline_Are_Visited()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"));
            Pipeline pipeline = new Pipeline(sprint);
            PipelineComposite pipelineComposite = new PipelineComposite(PipelineActionType.SOURCE);
            var compositeMock = new Mock<PipelineComposite>(PipelineActionType.SOURCE);
            var actionMock = new Mock<PipelineAction>("test", PipelineActionType.SOURCE);
            pipelineComposite.Add(compositeMock.Object);
            pipelineComposite.Add(actionMock.Object);

            pipeline.AddActivity(pipelineComposite);

            // Act
            pipeline.State.Start();

            // Assert
            compositeMock.Verify(x => x.Accept(It.IsAny<ExecutePipelineVisitor>()), Times.Once);
            actionMock.Verify(x => x.Accept(It.IsAny<ExecutePipelineVisitor>()), Times.Once);
        }
    }
}
