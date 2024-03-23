using AvansDevOps_11.NotifactionAdapterStrategy;
using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class NotificationEvent
    {
        public List<INotificationAdapterStrategy> subscribers = new();

        public void Subscribe(INotificationAdapterStrategy subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(INotificationAdapterStrategy subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void Notify(List<User> users, String msg, String subject)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.SendNotification(users, msg, subject);
            }
        }


    }
}
