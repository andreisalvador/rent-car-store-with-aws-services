using RentCarStore.Garage.Domain.Enums;

namespace RentCarStore.Garage.Domain.Messaging.Messages
{
    internal record CarCreatedEvent
    {
        public Guid Id { get; init; }
        public CarCategory Category { get; init; }
        public Accessories Accessories { get; init; }
        public uint CurrentMileage { get; init; }
    }
}
