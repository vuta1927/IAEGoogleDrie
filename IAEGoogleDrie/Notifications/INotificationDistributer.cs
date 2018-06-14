using System;
using System.Threading.Tasks;
using IAEGoogleDrie.Domain.Services;

namespace IAEGoogleDrie.Notifications
{
    /// <summary>
    /// Used to distribute notifications to users.
    /// </summary>
    public interface INotificationDistributer : IDomainService
    {
        /// <summary>
        /// Distributes given notification to users.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        Task DistributeAsync(Guid notificationId);
    }
}