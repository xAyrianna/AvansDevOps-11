using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class RunningPipelineState: IPipelineState
    {
        private Pipeline _pipeline;
        public RunningPipelineState(Pipeline pipeline)
        {
            this._pipeline = pipeline;
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; pipeline is already running.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred during pipeline execution.");
            this._pipeline.State = new PipelineErrorState(this._pipeline);
        }

        public void Finish()
        {
            Console.WriteLine("Finishing pipeline execution.");
            this._pipeline.State = new FinishedPipelineState(this._pipeline);
        }

        public void Restart()
        {
            Console.WriteLine("State transition not allowed; pipeline is running.");
        }
    }
}
