using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class CreatedPipelineState: IPipelineState
    {
        private Pipeline Pipeline;
        public CreatedPipelineState(Pipeline pipeline) { 
            this.Pipeline = pipeline;
        }
        public void Start()
        {
            Console.WriteLine("Starting pipeline execution.");
            this.Pipeline.State = new RunningPipelineState(this.Pipeline);
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot be finished.");
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot have an error.");
        }
    }   
    {
    }
}
