using AvansDevOps_11.NotifactionAdapterStrategy;
using AvansDevOps_11.PipelineClasses;
using AvansDevOps_11.SprintStates;
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
        public List<Developer> developers = new();
        public ScrumMaster ScrumMaster { get; set; }
        public ISprintState State { get; set; }
        public Pipeline? Pipeline { get; set; }
        public bool Review { get; set; }
        public Document? ReviewSummary { get; set; }

        public NotificationEvent NotificationEvent { get; set; }

        public Sprint(Project project, ScrumMaster scrumMaster)
        {
            Project = project;
            ScrumMaster = scrumMaster;
            State = new CreatedSprintState(this);

            NotificationEvent = new NotificationEvent();
            NotificationEvent.Subscribe(new EmailAdapterStrategy());
            NotificationEvent.Subscribe(new SMSAdapterStrategy());
            NotificationEvent.Subscribe(new SlackAdapterStrategy());
        }
        
    }
}