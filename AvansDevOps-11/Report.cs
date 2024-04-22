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
        public HashSet<IExportStrategy> ExportFormats = new();
        public string ReportText { get; set; }

        public Report(string report, HashSet<IExportStrategy> exportFormats)
        {
            ReportText = report;
            ExportFormats = exportFormats;
        }

        public void Export()
        {
            foreach (var exportStrategy in ExportFormats)
            {
                exportStrategy.Export(this);
            }
        }
    }
}
