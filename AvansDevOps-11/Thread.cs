using AvansDevOps_11.NotificationAdapterStrategy;
using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class Thread
    {
        HashSet<User> UsersInThread = new();
        List<ThreadReaction> Reactions = new();
        NotificationEvent NotificationEvent = new();

        public void AddUser(User user)
        {
            UsersInThread.Add(user);
        }

        public void RemoveUser(User user)
        {
            UsersInThread.Remove(user);
        }

        public void AddReaction(ThreadReaction reaction)
        {
            Reactions.Add(reaction);
            NotificationEvent.Notify(UsersInThread.ToList(), $"Reaction added to thread", "Reaction added");
        }

        public void RemoveReaction(ThreadReaction reaction)
        {
            Reactions.Remove(reaction);
        }
        
    }
}