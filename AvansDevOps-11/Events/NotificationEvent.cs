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
        public List<INotificationAdapter> Subscribers = new();

        public void Subscribe(INotificationAdapter subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public void Unsubscribe(INotificationAdapter subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        public void Notify(List<User> users, string msg, string subject)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.SendNotification(users, msg, subject);
            }
        }
    }
}
