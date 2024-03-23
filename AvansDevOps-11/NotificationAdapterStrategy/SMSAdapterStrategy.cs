using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.NotificationAdapterStrategy
{
    public class SMSAdapterStrategy : INotificationAdapterStrategy
    {
        public void SendNotification(List<User> users, string msg, string subject)
        {
            throw new NotImplementedException();
        }
    }
}