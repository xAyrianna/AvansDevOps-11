using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.SprintStates
{
    public class InProgressSprintState : ISprintState
    {
        private readonly Sprint _sprint;

        public InProgressSprintState(Sprint sprint)
        {
            _sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint has already started.");
        }
        public void Cancel()
        {
            Console.WriteLine("State transition not allowed; sprint is in progress and cannot be cancelled.");
        }

        public void Finish()
        {
            Console.WriteLine("Finishing sprint.");
            _sprint.State = new FinishedSprintState(_sprint);
        }

        public void Approve()
        {
            Console.WriteLine("State transition not allowed; sprint is in progress and cannot be approved.");
        }

        public void FinishPipeline()
        {
            Console.WriteLine("State transition not allowed; sprint is in progress and no pipeline is running.");
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is not in review.");
        }


    }
}