using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses
{
    public interface IPipelineActivity
    {
        public void Accept(PipelineVisitor visitor);
    }
}