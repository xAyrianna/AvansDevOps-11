using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class CanceledSprintState : ISprintState
    {
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint is canceled.");
        }

        public void Cancel()
        {
            Console.WriteLine("State transition not allowed; sprint is canceled.");
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; sprint is canceled.");
        }

        public void Approve()
        {
            Console.WriteLine("State transition not allowed; sprint is canceled.");
        }


        public void FinishPipeline()
        {
            Console.WriteLine("State transition not allowed; sprint is canceled.");
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is canceled.");
        }
    }
}