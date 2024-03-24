using AvansDevOps_11.Users;

namespace AvansDevOps_11
{
    public class Activity : SCM
    {
        public Developer Developer;
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public Activity(Developer developer, string title, string description)
        {
            Developer = developer;
            Title = title;
            Description = description;
            IsDone = false;
        }

        public void Finish()
        {
            IsDone = true;
        }

        public void ReOpen() 
        {
            IsDone = false;
        }
    }
}