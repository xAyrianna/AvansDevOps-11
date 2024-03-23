using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class InReviewSprintState : ISprintState
    {
        private Sprint _sprint;
        public InReviewSprintState(Sprint sprint)
        {
            this._sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint is in review and cannot be started.");
        }

        public void Cancel()
        {
            Console.WriteLine("State transition not allowed; sprint is in review and cannot be canceled.");
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; sprint has already finished.");
        }

        public void Approve()
        {
            Console.WriteLine("State transition not allowed; sprint has already been approved.");
        }

        public void FinishPipeline()
        {
            Console.WriteLine("State transition not allowed; sprint is in review and no pipeline is running.");
        }

        public void FinishReview()
        {
            if (_sprint.ReviewSummary != null)
            {
                Console.WriteLine("Closing sprint.");
                _sprint.SprintState = new ClosedSprintState();
            }
            else
            {
                Console.WriteLine("State transition not allowed; review summary needs to uploaded.");
            }
        }

    }
}