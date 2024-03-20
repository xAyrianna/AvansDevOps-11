using AvansDevOps_11.SprintStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public abstract class Sprint
    {
        public ISprintState SprintState { get; set; }
        public Pipeline? Pipeline { get; set; }
        public Sprint()
        {
            SprintState = new CreatedSprintState(this);
        }
        
    }
}