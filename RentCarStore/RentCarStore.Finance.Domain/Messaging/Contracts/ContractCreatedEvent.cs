using RentCarStore.Core.Messaging;

namespace RentCarStore.Finance.Domain.Messaging.Contracts
{
    internal record ContractCreatedEvent : IMessage
    {
        public string Code { get; init; }
        public Guid CarId { get; init; }
        public DateTime WithdrawAt { get; init; }
        public DateTime ReturnAt { get; init; }
        public Guid CustomerId { get; init; }
    }
}
