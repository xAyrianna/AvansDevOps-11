using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class FinishedPipelineState: IPipelineState
    {
        private Pipeline _pipeline;

        public FinishedPipelineState(Pipeline pipeline)
        {
            _pipeline = pipeline;
            // event: pipeline finished, needs to call sprint.state.finishpipeline (changed review & close to one function)
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");  
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");
        }
    }
}
