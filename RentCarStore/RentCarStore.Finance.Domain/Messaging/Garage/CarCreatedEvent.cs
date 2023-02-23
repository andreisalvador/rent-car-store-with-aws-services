using RentCarStore.Core.Messaging;
using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Domain.Messaging.Garage
{
    public class CarCreatedEvent : IMessage
    {
        public Guid Id { get; init; }
        public CarCategory Category { get; init; }
    }
}
