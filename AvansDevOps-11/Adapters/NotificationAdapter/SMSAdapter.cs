using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.Adapters.NotificationAdapter
{
    public class SMSAdapter : INotificationAdapter
    {
        public void SendNotification(List<User> users, string msg, string subject)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Sending SMS to {user.PhoneNumber}. \n{msg}");
            }
        }
    }
}