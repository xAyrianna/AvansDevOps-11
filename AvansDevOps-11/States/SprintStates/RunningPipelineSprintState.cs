using AvansDevOps_11.States.PipelineStates;

namespace AvansDevOps_11.States.SprintStates
{
    public class RunningPipelineSprintState : ISprintState
    {
        private readonly Sprint _sprint;
        public RunningPipelineSprintState(Sprint sprint)
        {
            _sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint is already releasing.");
        }

        public void Cancel()
        {
            if (_sprint.Pipeline!.State.GetType() == typeof(PipelineErrorState))
            {
                if (!_sprint.Review)
                {
                    Console.WriteLine("Canceling sprint.");
                    _sprint.State = new CanceledSprintState(_sprint, "Pipeline did not run succesfully.");
                }
                else
                {
                    Console.WriteLine("Pipeline canceled; starting review");
                    _sprint.State = new InReviewSprintState(_sprint);
                }
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
            if (_sprint.Pipeline!.State.GetType() == typeof(FinishedPipelineState))
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
            } else
            {
                Console.WriteLine("State transition not allowed; pipeline is not finished.");
            }
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is not in review.");
        }

    }
}