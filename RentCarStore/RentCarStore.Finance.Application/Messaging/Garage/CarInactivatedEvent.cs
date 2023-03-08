using RentCarStore.Core.Messaging;

namespace RentCarStore.Finance.Application.Messaging.Garage
{
    public class CarInactivatedEvent : IMessage
    {
        public Guid Id { get; set; }
    }
}
