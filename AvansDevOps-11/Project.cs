using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class Project
    {
        public string Name;
        public ProductOwner ProductOwner;
        public List<Sprint> Sprints = [];

        public Project(string name, ProductOwner productOwner)
        {
            Name = name;
            ProductOwner = productOwner;
        }
        
    }
}