using Amazon.SQS.Model;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Finance.Api.BackgroundServices.Base;
using RentCarStore.Finance.Application.Messaging.Contracts;
using RentCarStore.Finance.Application.Messaging.Contracts.Handlers.Interfaces;
using RentCarStore.Finance.Domain.Constants.Messaging;

namespace RentCarStore.Finance.Api.BackgroundServices
{
    public class ContractConsumerService : BaseConsumerService<ContractConsumerService>
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public ContractConsumerService(ISqsConsumer sqs, ILogger<ContractConsumerService> logger, IServiceScopeFactory scopeFactory) : base(sqs, logger)
        {
            _scopeFactory = scopeFactory;
        }

        public override string GetQueueName() => QueueNames.CONTRACT_FINANCE_QUEUE;

        public override async Task ProcessMessage(string messageType, Message message)
        {
            switch (messageType)
            {
                case nameof(ContractCreatedEvent):
                    await ProcessContractCreatedEvent(message);
                    break;
                default:
                    throw new InvalidMessageContentsException($"Message type '{messageType} could not be handled.'");
            }
        }

        private async Task ProcessContractCreatedEvent(Message message)
        {
            ContractCreatedEvent @event = DeserializeFromMessage<ContractCreatedEvent>(message);

            using var scope = _scopeFactory.CreateAsyncScope();
            IContractsEventHandler handler = scope.ServiceProvider.GetRequiredService<IContractsEventHandler>();
            await handler.Handle(@event);
        }
    }
}
