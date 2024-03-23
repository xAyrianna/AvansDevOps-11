using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class RunningPipelineState: IPipelineState
    {
        private Pipeline Pipeline;
        public RunningPipelineState(Pipeline pipeline)
        {
            this.Pipeline = pipeline;
        }

        public void Error()
        {
            Console.WriteLine("An error occurred during pipeline execution.");
            this.Pipeline.State = new PipelineErrorState(this.Pipeline);
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
