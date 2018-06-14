using IAEGoogleDrie.BackgroundJobs;
using IAEGoogleDrie.Dependency;
using IAEGoogleDrie.Threading;

namespace IAEGoogleDrie.Notifications
{
    public class NotificationDistributerJob : BackgroundJob<NotificationDistributerJobArgs>, ITransientDependency
    {
        private readonly INotificationDistributer _notificationDistributer;

        public NotificationDistributerJob(INotificationDistributer notificationDistributer)
        {
            _notificationDistributer = notificationDistributer;
        }

        public override void Execute(NotificationDistributerJobArgs args)
        {
            AsyncHelper.RunSync(() => _notificationDistributer.DistributeAsync(args.NotificationId));
        }
    }
}