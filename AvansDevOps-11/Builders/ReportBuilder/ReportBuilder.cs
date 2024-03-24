using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AvansDevOps_11.Builders.ReportBuilder
{
    public class ReportBuilder
    {
        private Sprint _sprint;
        private string? _header;
        private string? _footer;
        private string? _team;
        private string? _currentProgress;

        public ReportBuilder(Sprint sprint)
        {
            _sprint = sprint;
        }

        public void AddHeader(string header)
        {
            _header = header;
        }

        public void AddFooter(string footer)
        {
            _footer = footer;
        }

        public void AddTeam()
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
        }

        public void AddProgress()
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
        }

        public Report GetReport()
        {
            StringBuilder report = new StringBuilder();
            if (_header is not null) report.AppendLine(_header);
            report.AppendLine("Sprint report: " + _sprint.Name);
            if (_team is not null) report.AppendLine(_team);
            if (_currentProgress is not null) report.AppendLine(_currentProgress);
            if (_footer is not null) report.AppendLine(_footer);
            return new Report(report.ToString());
        }

    }
}
