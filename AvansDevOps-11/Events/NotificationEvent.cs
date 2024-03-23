using AvansDevOps_11.Adapters.NotificationAdapter;
using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.Events
{
    public class NotificationEvent
    {
        public List<INotificationAdapter> subscribers = new();

        public void Subscribe(INotificationAdapter subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(INotificationAdapter subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void Notify(List<User> users, string msg, string subject)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.SendNotification(users, msg, subject);
            }
        }
    }
}
