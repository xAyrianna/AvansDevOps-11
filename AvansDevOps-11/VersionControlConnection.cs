using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class VersionControlConnection
    {
        public string Link;
        public VersionControlConcept VersionControlConcept;
        public VersionControlConnection(string link, VersionControlConcept versionControlConcept)
        {
            Link = link;
            VersionControlConcept = versionControlConcept;
        }
    }
}