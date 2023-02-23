using RentCarStore.Core.Messaging;

namespace RentCarStore.Garage.Domain.Messaging.Messages
{
    internal record CarInactivatedEvent : IMessage
    {
        public Guid Id { get; set; }
    }
}
