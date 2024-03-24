using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class Thread
    {
        public User ThreadOwner;
        public string Subject { get; set; }
        public string? Description { get; set; }
        public bool IsClosed { get; set; } = false;
        HashSet<User> UsersInThread = new();
        List<ThreadReaction> Reactions = new();
        BacklogItem BacklogItem;

        public Thread(BacklogItem backlogItem, User user, string subject, string? description = null)
        {
            BacklogItem = backlogItem;
            ThreadOwner = user;
            UsersInThread.Add(user);
            Subject = subject;
            Description = description;
        }

        public void AddReaction(ThreadReaction reaction)
        {
            Reactions.Add(reaction);
            UsersInThread.Add(reaction.User);
            BacklogItem.Sprint.NotificationEvent.Notify(UsersInThread.ToList(), $"Reaction added to thread", "Reaction added");
        }

    }
}