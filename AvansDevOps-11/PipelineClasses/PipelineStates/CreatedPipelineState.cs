using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class CreatedPipelineState: IPipelineState
    {
        private Pipeline _pipeline;
        public CreatedPipelineState(Pipeline pipeline) { 
            this._pipeline = pipeline;
        }
        public void Start()
        {
            Console.WriteLine("Starting pipeline execution.");
            this._pipeline.State = new RunningPipelineState(this._pipeline);
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot be finished.");
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot have an error.");
        }

        public void Restart()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot be restarted.");
        }
    }   
}
