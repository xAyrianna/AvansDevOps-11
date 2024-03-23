using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.SprintStates
{
    public class ClosedSprintState : ISprintState
    {
        public void Start()
        {
            Console.WriteLine("State transition not allowed; sprint is closed.");
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; sprint is closed.");
        }

        public void Cancel()
        {
            Console.WriteLine("State transition not allowed; sprint is closed.");
        }

        public void Approve()
        {
            Console.WriteLine("State transition not allowed; sprint is closed.");
        }

        public void FinishPipeline()
        {
            Console.WriteLine("State transition not allowed; sprint is closed.");
        }

        public void FinishReview()
        {
            Console.WriteLine("State transition not allowed; sprint is closed.");
        }
    }
}
