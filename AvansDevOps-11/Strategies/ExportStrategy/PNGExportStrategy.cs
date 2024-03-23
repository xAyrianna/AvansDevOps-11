using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.Strategies.ExportStrategy
{
    public class PNGExportStrategy : IExportStrategy
    {
        public void Export(Report report)
        {
            Console.WriteLine("Exporting report to PNG.");
        }
    }
}