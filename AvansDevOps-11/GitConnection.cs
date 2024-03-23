using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class GitConnection
    {
        public string Link;
        public GitControlConcept GitControlConcept;
        public GitConnection(string link, GitControlConcept gitControlConcept)
        {
            Link = link;
            GitControlConcept = gitControlConcept;
        }
    }
}