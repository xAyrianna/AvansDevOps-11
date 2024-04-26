using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Composites.PipelineComposite;

namespace AvansDevOps_11.Visitors
{
    public abstract class PipelineVisitor
    {
        public abstract void Visit(Pipeline pipeline);
        public abstract void Visit(PipelineComposite composite);
        public abstract void Visit(PipelineAction action);
    }
}