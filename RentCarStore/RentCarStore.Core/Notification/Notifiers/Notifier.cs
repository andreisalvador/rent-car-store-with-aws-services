using MediatR;
using RentCarStore.Core.Notification.Notifiers.Interfaces;

namespace RentCarStore.Core.Notification.Notifiers
{
    public class Notifier : INotifier
    {
        private readonly IMediator _mediator;

        public Notifier(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Notify<TNotification>(TNotification notification) where TNotification : INotification
            => _mediator.Publish(notification);
    }
}
