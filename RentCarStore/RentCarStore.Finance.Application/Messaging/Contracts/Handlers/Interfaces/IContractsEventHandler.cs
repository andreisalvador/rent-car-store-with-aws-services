namespace RentCarStore.Finance.Application.Messaging.Contracts.Handlers.Interfaces
{
    public interface IContractsEventHandler
    {
        Task Handle(ContractCreatedEvent contractCreatedEvent);
    }
}
