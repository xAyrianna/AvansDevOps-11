using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Visitors;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public interface IPipelineActivity
    {
        public void Accept(PipelineVisitor visitor);
    }
}