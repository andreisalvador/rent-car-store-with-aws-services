using RentCarStore.Core.Messaging;

namespace RentCarStore.Finance.Application.Messaging.Contracts
{
    public record ContractCreatedEvent : IMessage
    {
        public string Code { get; init; }
        public Guid CarId { get; init; }
        public DateTime WithdrawAt { get; init; }
        public DateTime ReturnAt { get; init; }
        public Guid CustomerId { get; init; }
    }
}
