using AvansDevOps_11.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.PipelineStates
{
    public class RunningPipelineState : IPipelineState
    {
        private readonly Pipeline _pipeline;
        public RunningPipelineState(Pipeline pipeline)
        {
            _pipeline = pipeline;
            PipelineVisitor pipelineVisitor = new ExecutePipelineVisitor();
            _pipeline.Accept(pipelineVisitor);
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; pipeline is already running.");
        }

        public void Error()
        {
            Console.WriteLine("An error occurred during pipeline execution.");
            _pipeline.State = new PipelineErrorState(_pipeline);
        }

        public void Finish()
        {
            Console.WriteLine("Finishing pipeline execution.");
            _pipeline.State = new FinishedPipelineState(_pipeline);
        }

        public void Restart()
        {
            Console.WriteLine("State transition not allowed; pipeline is running.");
        }
    }
}
