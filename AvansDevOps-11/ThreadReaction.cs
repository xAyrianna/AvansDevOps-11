using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class ThreadReaction
    {
        public User User;
        public string Reaction;

        public ThreadReaction(User user, string reaction)
        {
            this.User = user;
            this.Reaction = reaction;
        }
    }
}