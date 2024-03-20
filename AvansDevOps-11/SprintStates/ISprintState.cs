using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public interface ISprintState
    {
        public void Start();
        public void Finish();
        public void Cancel();
        public void StartPipeline();
        public void Close();
        public void FinishPipeline();
        public void PipelineError();
        public void Review();
    }
}