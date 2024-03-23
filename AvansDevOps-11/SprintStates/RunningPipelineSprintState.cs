using AvansDevOps_11.PipelineClasses.PipelineStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class RunningPipelineSprintState : ISprintState
    {
        private Sprint _sprint;
        public RunningPipelineSprintState(Sprint sprint)
        {
            this._sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint is already releasing.");
        }

        public void Cancel()
        {
            if ((_sprint.Pipeline != null) && (_sprint.Pipeline.State.GetType() == typeof(PipelineErrorState)))
            {
                Console.WriteLine("Canceling sprint.");
                _sprint.State = new CanceledSprintState(_sprint, "Pipeline did not run succesfully.");
            }
            else
            {
                Console.WriteLine("State transition not allowed; sprint cannot be cancelled.");
            }
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
            if ((_sprint.Pipeline != null) && ((_sprint.Pipeline.State.GetType() == typeof(FinishedPipelineState)) || (_sprint.Pipeline.State.GetType() == typeof(PipelineErrorState))))
            {
                if (_sprint.Review)
                {
                    Console.WriteLine("Starting sprint review process");
                    _sprint.State = new InReviewSprintState(_sprint);
                }
                else
                {
                    Console.WriteLine("Closing sprint.");
                    _sprint.State = new ClosedSprintState(_sprint);
                }   
            }
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is not in review.");
        }

    }
}