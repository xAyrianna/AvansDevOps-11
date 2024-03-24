using AvansDevOps_11.Adapters.NotificationAdapter;
using AvansDevOps_11.Events;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public abstract class Sprint
    {
        public Project Project;
        public string Name { get { return Name; } set { if (State is CreatedSprintState) { Name = value; } else { Console.WriteLine("Can no longer change sprint name."); } } }
        public DateTime StartDate { get { return StartDate; } set { if (State is CreatedSprintState) { StartDate = value; } else { Console.WriteLine("Can no longer change start date."); } } }
        public DateTime EndDate { get { return EndDate; } set { if (State is CreatedSprintState) { EndDate = value; } else { Console.WriteLine("Can no longer change end date."); } } }
        public List<BacklogItem> BacklogItems = new();
        public List<Developer> Developers = new();
        public List<Tester> Testers = new();
        public ScrumMaster ScrumMaster;
        public ISprintState State { get; set; }
        public Pipeline? Pipeline { get; set; }
        public bool Review;
        public Document? ReviewSummary { get; set; }

        public NotificationEvent NotificationEvent { get; set; }


        public Sprint(Project project, ScrumMaster scrumMaster)
        {
            Project = project;
            ScrumMaster = scrumMaster;
            State = new CreatedSprintState(this);

            NotificationEvent = new NotificationEvent();
            NotificationEvent.Subscribe(new SlackAdapter());
        }

        public void AddNotificationStrategy(INotificationAdapter strategy)
        {
            NotificationEvent.Subscribe(strategy);
        }

        public void RemoveNotificationStrategy(INotificationAdapter strategy)
        {
            NotificationEvent.Unsubscribe(strategy);
        }

        public void AddBacklogItem(BacklogItem backlogItem)
        {
            if (State is CreatedSprintState)
            {
                BacklogItems.Add(backlogItem);
            }
            else
            {
                Console.WriteLine("Can no longer add backlog items to this sprint.");
            }
        }

        public void RemoveBacklogItem(BacklogItem backlogItem)
        {
            if (State is CreatedSprintState)
            {
                BacklogItems.Remove(backlogItem);
            }
            else
            {
                Console.WriteLine("Can no longer remove backlog items from this sprint.");
            }
        }

        public void AddDeveloper(Developer developer)
        {
            Developers.Add(developer);
        }

        public void RemoveDeveloper(Developer developer)
        {
            Developers.Remove(developer);
        }

        public void AddTester(Tester tester)
        {
            Testers.Add(tester);
        }

        public void RemoveTester(Tester tester)
        {
            Testers.Remove(tester);
        }

        public void UploadReviewSummary()
        {
            if (Review && State is InReviewSprintState)
            {
                ReviewSummary = new Document();
                State.FinishReview();
            }
            else
            {
                Console.WriteLine("Can not upload review summary when review is not needed.");
            }
        }

        public int GetTotalStoryPoints()
        {
            int totalStoryPoints = 0;
            foreach (var backlogItem in BacklogItems)
            {
                totalStoryPoints += backlogItem.StoryPoints;
            }
            return totalStoryPoints;
        }
    }
}