using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.Users
{
    public class ScrumMaster(string Name, string SlackUsername) : User(Name, SlackUsername)
    {
    }
}