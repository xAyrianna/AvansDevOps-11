using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.Users
{
    public abstract class User
    {
        public string Name { get; set; }
        public string SlackUsername { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }


        protected User(string name, string slackUsername)
        {
            Name = name;
            SlackUsername = slackUsername;
        }

    }
}