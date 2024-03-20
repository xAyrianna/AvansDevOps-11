using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class InProgressSprintState : ISprintState
    {
        private Sprint Sprint;

        public InProgressSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("Sprint is already started.");
        }
        public void Cancel()
        {
            Console.WriteLine("Sprint is in progress and cannot be cancelled.");
        }

        public void Close()
        {
            Console.WriteLine("Sprint is in progress and cannot be closed.");
        }

        public void Finish()
        {
            Sprint.SprintState = new FinishedSprintState(Sprint);
            Console.WriteLine("Finishing sprint.");
        }

        public void StartPipeline()
        {
            Console.WriteLine("Sprint is in progress and cannot be released.");
        }

        public void FinishPipeline()
        {
            Console.WriteLine("There is no pipeline in progress.");
        }

        public void PipelineError()
        {
            Console.WriteLine("Sprint is not releasing.");
        }

        public void Review()
        {
            Console.WriteLine("Sprint is in progress and cannot be reviewed.");
        }

        
    }
}