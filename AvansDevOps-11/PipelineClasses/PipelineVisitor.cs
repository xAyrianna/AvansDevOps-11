using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses
{
    public abstract class PipelineVisitor
    {
        public abstract void Visit(Pipeline pipeline);
        public abstract void Visit(PipelineComposite composite);
        public abstract void Visit(PipelineAction command);
    }
}