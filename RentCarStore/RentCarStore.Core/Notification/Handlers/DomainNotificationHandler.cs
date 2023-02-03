using MediatR;
using RentCarStore.Core.Notification.Interfaces;

namespace RentCarStore.Core.Notification.Handlers
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>, INotificationHandler<DomainNotification>
    {
        private readonly List<DomainNotification> _notifications;
        public IReadOnlyCollection<DomainNotification> Notifications => _notifications.AsReadOnly();

        public DomainNotificationHandler() => _notifications = new List<DomainNotification>();

        public IEnumerable<DomainNotification> GetByKey(string key)
        {
            return _notifications.Where(n => n.Key.Equals(key));
        }
        public bool HasNotifications() => _notifications.Count > 0;

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}
