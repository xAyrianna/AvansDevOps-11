using AvansDevOps_11.Strategies.ExportStrategy;
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
        public string ReportText { get; set; }

        public Report(string report)
        {
            ReportText = report;
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
