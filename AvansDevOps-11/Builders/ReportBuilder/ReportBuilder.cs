using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps_11.Strategies.ExportStrategy;


namespace AvansDevOps_11.Builders.ReportBuilder
{
    public class ReportBuilder
    {
        private readonly Sprint _sprint;
        private string? _header;
        private string? _footer;
        private string? _team;
        private string? _currentProgress;
        private readonly HashSet<IExportStrategy> _exportFormats = new();

        public ReportBuilder(Sprint sprint)
        {
            _sprint = sprint;
        }

        public ReportBuilder AddHeader(string header)
        {
            _header = header;
            return this;
        }

        public ReportBuilder AddFooter(string footer)
        {
            _footer = footer;
            return this;
        }

        public ReportBuilder AddTeam()
        {
            StringBuilder team = new StringBuilder();
            team.AppendLine("Team members: ");
            team.AppendLine("Product owner: " + _sprint.Project.ProductOwner.Name);
            team.AppendLine("Scrum master: " + _sprint.ScrumMaster.Name);
            if (_sprint.Developers.Count == 0) team.AppendLine("No developers in team.");
            else
            {
                team.AppendLine("Developers: ");
                foreach (var teamMember in _sprint.Developers)
                {
                    team.AppendLine(teamMember.Name);
                }
            }
            if (_sprint.Testers.Count == 0) team.AppendLine("No testers in team.");
            else
            {
                team.AppendLine("Testers: ");
                foreach (var teamMember in _sprint.Testers)
                {
                    team.AppendLine(teamMember.Name);
                }
            }

            _team = team.ToString();
            return this;
        }

        public ReportBuilder AddProgress()
        {
            StringBuilder progress = new StringBuilder();
            progress.AppendLine("Story point progress: ");
            foreach (var backlogItem in _sprint.BacklogItems)
            {
                progress.AppendLine(backlogItem.Title + ": " + backlogItem.StoryPoints);
                progress.AppendLine("Status: " + backlogItem.ItemState.GetType().Name);
                progress.AppendLine("--------------------");
            }
            _currentProgress = progress.ToString();
            return this;
        }

        public ReportBuilder AddExportFormat(IExportStrategy exportFormat)
        {
            _exportFormats.Add(exportFormat);
            return this;
        }

        public Report GetReport()
        {
            if (_exportFormats.Count == 0) throw new InvalidOperationException("No export formats added.");

            StringBuilder reportText = new StringBuilder();
            if (_header is not null) reportText.AppendLine(_header);
            reportText.AppendLine("Sprint report: " + _sprint.Name);
            if (_team is not null) reportText.AppendLine(_team);
            if (_currentProgress is not null) reportText.AppendLine(_currentProgress);
            if (_footer is not null) reportText.AppendLine(_footer);

            Report report = new Report(reportText.ToString(), _exportFormats);
            return report;
        }

    }
}
