using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.Strategies.ExportStrategy
{
    public interface IExportStrategy
    {
        public void Export(Report report);
    }
}