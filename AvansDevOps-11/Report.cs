using AvansDevOps_11.ExportStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class Report
    {
        List<IExportStrategy> ExportStrategies = new();

        public void AddHeader()
        {
            // Add header
        }

        public void AddFooter()
        {
            // Add footer
        }

        public void AddTeam()
        {
            // Add team
        }

        public void AddBurndownChart()
        {
            // Add burndown chart
        }

        public void AddExportStrategy(IExportStrategy exportStrategy)
        {
            ExportStrategies.Add(exportStrategy);
        }

        public void Export()
        {
            foreach (var exportStrategy in ExportStrategies)
            {
                exportStrategy.Export(this);
            }
        }


    }
}
