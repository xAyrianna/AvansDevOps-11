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
        public void Approve();
        public void FinishPipeline();
        public void FinishReview();
    }
}