using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class CanceledSprintState : ISprintState
    {
        private Sprint Sprint;
        public CanceledSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("Sprint has been canceled and cannot be restarted.");
        }

        public void Cancel()
        {
            Console.WriteLine("Sprint has already been canceled.");
        }

        public void Close()
        {
            Console.WriteLine("Sprint has been canceled and cannot be closed.");
        }

        public void Finish()
        {
            Console.WriteLine("Sprint has been canceled.");
        }

        public void StartPipeline()
        {
            Console.WriteLine("Sprint has been canceled and cannot be released.");
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
            Console.WriteLine("Sprint has been canceled and cannot be reviewed.");
        }
        
    }
}