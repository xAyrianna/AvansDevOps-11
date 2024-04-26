using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.SprintStates
{
    public class CanceledSprintState : ISprintState
    {
        public CanceledSprintState(Sprint sprint, string reason)
        {
            List<User> ToBeNotified = new List<User>()
            {
                sprint.ScrumMaster,
                sprint.Project.ProductOwner
            };
            sprint.NotificationEvent.Notify(ToBeNotified, $"{reason} \nSprint has been canceled.", "Sprint Canceled");
        }

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