using RentCarStore.Core.Messaging;

namespace RentCarStore.Garage.Domain.Messaging.Messages
{
    public class CarInactivatedEvent : IMessage
    {
        public Guid Id { get; set; }
    }
}
