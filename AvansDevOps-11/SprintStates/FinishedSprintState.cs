using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class FinishedSprintState : ISprintState
    {
        private Sprint Sprint;
        public FinishedSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("Sprint is already finished.");
        }

        public void Cancel()
        {
            Console.WriteLine("Canceling sprint.");
            Sprint.SprintState = new CanceledSprintState(Sprint);
        }

        public void Close()
        {
            Console.WriteLine("Sprint cannot be closed yet.");
        }

        public void Finish()
        {
            Console.WriteLine("Sprint has already finished.");
        }

        public void StartPipeline()
        {
            if (Sprint.Pipeline != null)
            {
                Console.WriteLine("Starting developoment pipeline.");
                Sprint.SprintState = new RunningPipelineSprintState(Sprint);
            }
            else
            {
                Console.WriteLine("Sprint has no pipeline.");
            }
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
            if (Sprint.GetType() == typeof(ReviewSprint))
            {
                Console.WriteLine("Starting sprint review process.");
                Sprint.SprintState = new ReviewedSprintState(Sprint);
            }
            Console.WriteLine("Sprint cannot be reviewed.");
        }
        
    }
}