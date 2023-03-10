using RentCarStore.Core.Messaging;

namespace RentCarStore.Contracts.Domain.Messaging.Messages
{
    internal record ContractCreatedEvent : IMessage
    {
        public Guid Id { get; init; }
        public string Code { get; init; }
        public Guid CarId { get; init; }
        public DateTime WithdrawAt { get; init; }
        public DateTime ReturnAt { get; init; }
        public Guid CustomerId { get; init; }
    }
}
