using Amazon.SQS.Model;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Finance.Api.BackgroundServices.Base;
using RentCarStore.Finance.Domain.Constants.Messaging;

namespace RentCarStore.Finance.Api.BackgroundServices
{
    public class ContractConsumerService : BaseConsumerService<ContractConsumerService>
    {
        public ContractConsumerService(ISqsConsumer sqs, ILogger<ContractConsumerService> logger) : base(sqs, logger)
        {
           
        }

        public override string GetQueueName() => QueueNames.CONTRACT_FINANCE_QUEUE;

        public override Task ProcessMessage(string messageType, Message message)
        {
            throw new NotImplementedException();
        }
    }
}
