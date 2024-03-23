using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.SprintStates
{
    public class CreatedSprintState : ISprintState
    {
        private Sprint _sprint;
        public CreatedSprintState(Sprint sprint)
        {
            _sprint = sprint;
        }
        public void Start()
        {
            Console.WriteLine("Starting sprint.");
            _sprint.State = new InProgressSprintState(_sprint);
        }
        public void Cancel()
        {
            Console.WriteLine("State transition not allowed; sprint has not started yet and cannot be cancelled.");
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; sprint has not started yet and cannot be finished.");
        }

        public void Approve()
        {
            Console.WriteLine("State transition not allowed; sprint has not started yet and cannot be approved.");
        }

        public void FinishPipeline()
        {
            Console.WriteLine("State transition not allowed; sprint has not started yet and no pipeline is running.");
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is not in review.");
        }
    }
}