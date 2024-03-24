using AvansDevOps_11.States.ItemStates;
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;

namespace AvansDevOps_11
{
    public class BacklogItem : SCM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryPoints { get; set; }
        public Sprint Sprint;
        public List<Activity>? Activities;
        public Developer Developer;
        public IItemState ItemState { get; set; }
        public Dictionary<string, Thread> Threads = new Dictionary<string, Thread>();


        public BacklogItem(Sprint sprint, Developer developer, string title, string description, int storyPoints)
        {
            Sprint = sprint;
            Developer = developer;
            Title = title;
            Description = description;
            StoryPoints = storyPoints;
            ItemState = new ToDoItemState(this);
        }

        public void AddActivity(Activity activity)
        {
            if (Sprint.State is CreatedSprintState)
            {
                if (Activities == null)
                {
                    Activities = new List<Activity>();
                }
                Activities.Add(activity);
            }
            else
            {
                Console.WriteLine("Cannot add activity to item in sprint; Sprint has already started.");
            }

        }

        public void RemoveActivity(Activity activity)
        {
            if (Sprint.State is CreatedSprintState)
            {
                if (Activities == null)
                {
                    return;
                }
                Activities.Remove(activity);
            }
            else
            {
                Console.WriteLine("Cannot remove activity to item in sprint; Sprint has already started.");
            }
        }

        public void CreateThread(User user, string subject, string? description = null)
        {
            Threads.Add(subject, new Thread(this, user, subject, description));
        }

        public void DeleteThread(string subject)
        {
            Threads.Remove(subject);
        }
    }
}