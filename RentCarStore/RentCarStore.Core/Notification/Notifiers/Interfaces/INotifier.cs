using MediatR;

namespace RentCarStore.Core.Notification.Notifiers.Interfaces
{
    public interface INotifier
    {
        Task Notify<TNotification>(TNotification notification) where TNotification : INotification;
    }
}
