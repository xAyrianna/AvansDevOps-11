using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Users;

namespace AvansDevOps_11
{
    public class ReleaseSprint : Sprint
    {
        public ReleaseSprint(Project project, ScrumMaster scrumMaster) : base(project, scrumMaster)
        {   
            this.Review = false;
        }
    }
}