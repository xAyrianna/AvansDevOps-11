using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class PipelineErrorSprintState : ISprintState
    {
        private Sprint Sprint;
        public PipelineErrorSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("Sprint has already finished.");
        }

        public void Cancel()
        {
            Console.WriteLine("Canceling sprint.");
            Sprint.SprintState = new CanceledSprintState(Sprint);
        }

        public void Close()
        {
            
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public void StartPipeline()
        {
            throw new NotImplementedException();
        }

        public void PipelineError()
        {
            throw new NotImplementedException();
        }

        public void Review()
        {
            throw new NotImplementedException();
        }
        
    }
}