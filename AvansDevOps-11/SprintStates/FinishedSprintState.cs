using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class FinishedSprintState : ISprintState
    {
        private Sprint _sprint;
        public FinishedSprintState(Sprint sprint)
        {
            this._sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint cannot be started as it is already finished.");
        }

        public void Cancel()
        {
            Console.WriteLine("Canceling sprint.");
            _sprint.SprintState = new CanceledSprintState();
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; sprint has already finished.");
        }

        public void Approve()
        {
            Console.WriteLine("Sprint approved.");
            if (_sprint.Pipeline != null)
            {
                Console.WriteLine("Starting developoment pipeline.");
                _sprint.SprintState = new RunningPipelineSprintState(_sprint);
            }
            else if (_sprint.Review)
            {
                Console.WriteLine("Starting sprint review.");
                _sprint.SprintState = new InReviewSprintState(_sprint);
            }
            else
            {
                Console.WriteLine("Closing sprint.");
                _sprint.SprintState = new ClosedSprintState();
            }
        }

        public void FinishPipeline()
        {
            Console.WriteLine("State transition not allowed; there is no pipeline running.");
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is not in review.");
        }
    }
}