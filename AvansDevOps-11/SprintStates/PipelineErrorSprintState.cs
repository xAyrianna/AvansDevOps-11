using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class ReleaseErrorSprintState : ISprintState
    {
        private Sprint Sprint;
        public ReleaseErrorSprintState(Sprint sprint)
        {
            this.Sprint = sprint;
        }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
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