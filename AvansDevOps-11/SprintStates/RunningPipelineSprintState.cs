using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class RunningPipelineSprintState : ISprintState
    {
        private Sprint Sprint;
        public RunningPipelineSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("Sprint is already releasing.");
        }

        public void Cancel()
        {
            Console.WriteLine("Sprint cannot be cancelled while releasing.");
        }

        public void Close()
        {
            Console.WriteLine("Sprint cannot be closed while releasing.");
        }

        public void Finish()
        {
            Console.WriteLine("Sprint cannot be finished while releasing.");
        }

        public void StartPipeline()
        {
            Console.WriteLine("Pipeline is already running.");
        }

        public void FinishPipeline()
        {
            Console.WriteLine("Pipeline has finished.");
            Sprint.SprintState = new FinishedPipelineSprintState(Sprint);
        }
        public void PipelineError()
        {
            Console.WriteLine("Pipeline has an error.");
            Sprint.SprintState = new PipelineErrorSprintState(Sprint);
        }

        public void Review()
        {
            Console.WriteLine("Sprint is not ready for review.");
        }
        
  
    }
}