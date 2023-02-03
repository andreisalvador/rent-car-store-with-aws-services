using MediatR;

namespace RentCarStore.Core.Notification.Interfaces
{
    public interface IDomainNotificationHandler<TNotification> where TNotification : INotification
    {
        IReadOnlyCollection<TNotification> Notifications { get; }
        bool HasNotifications();
        IEnumerable<TNotification> GetByKey(string key);
    }
}
