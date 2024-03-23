using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class PipelineErrorState: IPipelineState
    {
        private Pipeline _pipeline;

        public PipelineErrorState(Pipeline pipeline)
        {
            this._pipeline = pipeline;
            // notification, pipeline has error, user needs to make a decision (restart or cancel)
        }
        public void Start()
        {
            Console.WriteLine("Restarting pipeline execution.");
            this._pipeline.State = new RunningPipelineState(this._pipeline);
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has an error.");
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has an error.");
        }
    }
}
