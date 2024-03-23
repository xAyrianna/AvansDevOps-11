using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.NotificationAdapterStrategy
{
    public interface INotificationAdapterStrategy
    {
        public void SendNotification(List<User> users, String msg, String subject);
    }
}