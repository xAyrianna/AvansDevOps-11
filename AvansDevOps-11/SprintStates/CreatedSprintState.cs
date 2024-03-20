using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class CreatedSprintState : ISprintState
    {
        private Sprint Sprint;
        public CreatedSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            Sprint.SprintState = new InProgressSprintState(Sprint);
            Console.WriteLine("Starting sprint.");
        }
        public void Cancel()
        {
            Console.WriteLine("Sprint has not started yet and cannot be cancelled.");
        }

        public void Close()
        {
            Console.WriteLine("Sprint has not started yet and cannot be closed.");
        }

        public void Finish()
        {
            Console.WriteLine("Sprint has not started yet and cannot be finished.");
        }

        public void StartPipeline()
        {
            Console.WriteLine("Sprint has not started yet and cannot be released.");
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
            Console.WriteLine("Sprint has not started yet and cannot be reviewed.");
        }

    }
}