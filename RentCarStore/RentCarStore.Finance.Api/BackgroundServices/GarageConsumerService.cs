using Amazon.SQS.Model;
using RentCarStore.Core.Messaging;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Finance.Api.BackgroundServices.Base;
using RentCarStore.Finance.Application.Messaging.Garage;
using RentCarStore.Finance.Application.Messaging.Garage.Handlers.Interface;
using RentCarStore.Finance.Domain.Constants.Messaging;

namespace RentCarStore.Finance.Api.BackgroundServices
{
    public class GarageConsumerService : BaseConsumerService<GarageConsumerService>
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public GarageConsumerService(ISqsConsumer sqs, ILogger<GarageConsumerService> logger, IServiceScopeFactory scopeFactory) : base(sqs, logger)
        {
            _scopeFactory = scopeFactory;
        }

        public override string GetQueueName() => QueueNames.GARAGE_FINANCE_QUEUE;

        public override async Task ProcessMessage(string messageType, Message message)
        {
            switch (messageType)
            {
                case nameof(CarCreatedEvent):
                    await ProcessCarCreatedEvent(message);
                    break;
                case nameof(CarInactivatedEvent):
                    await ProcessCarInactivatedEvent(message);
                    break;
                default:
                    throw new InvalidMessageContentsException($"Message type '{messageType} could not be handled.'");
            }
        }

        private async Task ProcessCarCreatedEvent(Message message)
        {
            CarCreatedEvent @event = DeserializeFromMessage<CarCreatedEvent>(message);

            using var scope = _scopeFactory.CreateAsyncScope();
            IGarageEventHandler handler = scope.ServiceProvider.GetRequiredService<IGarageEventHandler>();
            await handler.Handle(@event);
        }

        private async Task ProcessCarInactivatedEvent(Message message)
        {
            CarInactivatedEvent @event = DeserializeFromMessage<CarInactivatedEvent>(message);

            using var scope = _scopeFactory.CreateAsyncScope();
            IGarageEventHandler handler = scope.ServiceProvider.GetRequiredService<IGarageEventHandler>();
            await handler.Handle(@event);
        }
    }
}
