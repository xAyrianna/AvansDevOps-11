using AvansDevOps_11.PipelineClasses;
using AvansDevOps_11.SprintStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public abstract class Sprint
    {
        public ISprintState SprintState { get; set; }
        public Pipeline? Pipeline { get; set; }
        public bool Review { get; set; }
        public Document? ReviewSummary { get; set; }

        public Sprint()
        {
            SprintState = new CreatedSprintState(this);
        }
        
    }
}