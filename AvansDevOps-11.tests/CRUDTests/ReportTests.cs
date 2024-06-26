using AvansDevOps_11.Builders.ReportBuilder;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Strategies.ExportStrategy;
using AvansDevOps_11.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class ReportTests
    {
        private Sprint _sprint = new ReleaseSprint(new Project("Project", new ProductOwner("Product Owner", "PO")), new ScrumMaster("Scrum Master", "SM"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
        private Mock<IExportStrategy> mockExportStrategy = new Mock<IExportStrategy>();

        [Fact]
        public void Assert_ReportBuilder_Cannot_Be_Created_When_Sprint_Not_Closed()
        {
            // Arrange
            _sprint.State = new CreatedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act

            // Assert
            Assert.Null(reportBuilder);
        }

        [Fact]
        public void Assert_ReportBuilder_Can_Be_Created_When_Sprint_Closed()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act

            // Assert
            Assert.NotNull(reportBuilder);
        }

        [Fact]
        public void Assert_ExportFormat_Is_Added_To_Report()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act
            Assert.NotNull(reportBuilder);
            Report report = reportBuilder.AddExportFormat(mockExportStrategy.Object).GetReport();

            // Assert
            Assert.Contains(mockExportStrategy.Object, report.ExportFormats);
        }

        [Fact]
        public void Assert_Header_Is_Added_To_Report()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act
            Assert.NotNull(reportBuilder);
            Report report = reportBuilder.AddHeader("Header").AddExportFormat(mockExportStrategy.Object).GetReport();

            // Assert
            Assert.Contains("Header", report.ReportText);
        }

        [Fact]
        public void Assert_Footer_Is_Added_To_Report()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act
            Assert.NotNull(reportBuilder);
            Report report = reportBuilder.AddFooter("Footer").AddExportFormat(mockExportStrategy.Object).GetReport();

            // Assert
            Assert.Contains("Footer", report.ReportText);
        }

        [Fact]
        public void Assert_Team_Is_Added_To_Report_With_No_Developers_Or_Testers()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act
            Assert.NotNull(reportBuilder);
            Report report = reportBuilder.AddTeam().AddExportFormat(mockExportStrategy.Object).GetReport();

            // Assert
            Assert.Contains("Product Owner", report.ReportText);
            Assert.Contains("Scrum Master", report.ReportText);
        }

        [Fact]
        public void Assert_Team_Is_Added_To_Report_With_Developers_And_Testers()
        {
            // Arrange
            _sprint.Developers.Add(new Developer("Developer", "D"));
            _sprint.Testers.Add(new Tester("Tester", "T"));
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act
            Assert.NotNull(reportBuilder);
            Report report = reportBuilder.AddTeam().AddExportFormat(mockExportStrategy.Object).GetReport();

            // Assert
            Assert.Contains("Developer", report.ReportText);
            Assert.Contains("Tester", report.ReportText);
        }

        [Fact]
        public void Assert_Progress_Is_Added_To_Report()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();

            // Act
            Assert.NotNull(reportBuilder);
            Report report = reportBuilder.AddProgress().AddExportFormat(mockExportStrategy.Object).GetReport();

            // Assert
            Assert.Contains("Story point progress", report.ReportText);
        }

        [Fact]
        public void Assert_Report_Is_Exported()
        {
            // Arrange
            _sprint.State = new ClosedSprintState(_sprint);
            ReportBuilder? reportBuilder = _sprint.CreateReportBuilder();
            Assert.NotNull(reportBuilder);

            var mockExportStrategy = new Mock<IExportStrategy>();
            reportBuilder.AddExportFormat(mockExportStrategy.Object);
            _sprint.State = new ClosedSprintState(_sprint);
            
            Report report = reportBuilder.GetReport();

            // Act
            report.Export();

            // Assert
            mockExportStrategy.Verify(m => m.Export(report), Times.Once);
        }

        
    }
}