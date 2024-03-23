using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ExportStrategy
{
    public class PDFExportStrategy : IExportStrategy
    {
        public void Export(Report report)
        {
            Console.WriteLine("Exporting report to PDF.");
        }
    }
}