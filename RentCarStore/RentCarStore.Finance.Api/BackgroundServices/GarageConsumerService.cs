using Amazon.SQS.Model;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Finance.Api.BackgroundServices.Base;
using RentCarStore.Finance.Domain.Constants.Messaging;

namespace RentCarStore.Finance.Api.BackgroundServices
{
    public class GarageConsumerService : BaseConsumerService<GarageConsumerService>
    {
        public GarageConsumerService(ISqsConsumer sqs, ILogger<GarageConsumerService> logger) : base(sqs, logger)
        {

        }

        public override string GetQueueName() => QueueNames.GARAGE_FINANCE_QUEUE;

        public override Task ProcessMessage(string messageType, Message message)
        {
            throw new NotImplementedException();
        }
    }
}
