using System;
using System.Threading.Tasks;

namespace IAEGoogleDrie.Notifications
{
    public interface INotificationChannel
    {
        bool CanHandle(Type notificationDataType);
        Task ProcessAsync(UserNotificationInfo userNotificationsInfo);
    }
}