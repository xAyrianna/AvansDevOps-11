using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Composites.PipelineComposite;

namespace AvansDevOps_11.Visitors
{
    public class ExecutePipelineVisitor : PipelineVisitor
    {

        public override void Visit(Pipeline pipeline)
        {
            Console.WriteLine("Executing pipeline: " + pipeline.Sprint.Name);
        }
        public override void Visit(PipelineComposite composite)
        {
            Console.WriteLine("Executing composite: " + composite.Name);

        }
        public override void Visit(PipelineAction action)
        {
            Console.WriteLine("Executing command: " + action.Command);
        }
    }

}