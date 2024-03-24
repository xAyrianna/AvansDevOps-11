using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public abstract class SCM
    {
        public List<VersionControlConnection> VersionControlConnections = new();

        public void AddVersionControlConnection(VersionControlConnection versionControlConnection)
        {
            VersionControlConnections.Add(versionControlConnection);
        }

        public void RemoveVersionControlConnection(VersionControlConnection versionControlConnection)
        {
            VersionControlConnections.Remove(versionControlConnection);
        }

    }
}