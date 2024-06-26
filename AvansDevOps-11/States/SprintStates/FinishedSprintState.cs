

using AvansDevOps_11.Composites.PipelineComposite;

namespace AvansDevOps_11.States.SprintStates
{
    public class FinishedSprintState : ISprintState
    {
        private readonly Sprint _sprint;
        public FinishedSprintState(Sprint sprint)
        {
            _sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint cannot be started as it is already finished.");
        }

        public void Cancel()
        {
            Console.WriteLine("Canceling sprint.");
            _sprint.State = new CanceledSprintState(_sprint, "Results of the sprint are unsatisfactory.");
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
                if (_sprint.GetType() == typeof(ReleaseSprint) && _sprint.Pipeline.Activities.Last().ActionType != PipelineActionType.DEPLOY)
                {
                    Console.WriteLine("Pipeline does not end with a deploy action; please end with a deployment action.");
                    return;
                }
                Console.WriteLine("Starting development pipeline.");
                _sprint.State = new RunningPipelineSprintState(_sprint);
            }
            else if (_sprint.Review)
            {
                Console.WriteLine("Starting sprint review.");
                _sprint.State = new InReviewSprintState(_sprint);
            }
            else
            {
                Console.WriteLine("Closing sprint.");
                _sprint.State = new ClosedSprintState(_sprint);
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