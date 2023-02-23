using RentCarStore.Core.Messaging;

namespace RentCarStore.Finance.Domain.Messaging.Garage
{
    public class CarInactivatedEvent : IMessage
    {
        public Guid Id { get; set; }
    }
}
