using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class Project
    {
        public ProductOwner ProductOwner;

        public Project(ProductOwner productOwner)
        {
            ProductOwner = productOwner;
        }
        
    }
}