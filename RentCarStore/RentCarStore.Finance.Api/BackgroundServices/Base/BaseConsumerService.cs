using Amazon.SQS.Model;
using RentCarStore.Core.Messaging;
using RentCarStore.Core.Messaging.Helper;
using RentCarStore.Core.Messaging.Interfaces;
using System.Text.Json;

namespace RentCarStore.Finance.Api.BackgroundServices.Base
{
    public abstract class BaseConsumerService<TConsumer> : BackgroundService
    {
        private readonly ISqsConsumer _sqs;
        private readonly ILogger<TConsumer> _logger;

        public BaseConsumerService(ISqsConsumer sqs, ILogger<TConsumer> logger)
        {
            _sqs = sqs;
            _logger = logger;
        }

        public abstract string GetQueueName();
        public abstract Task ProcessMessage(string messageType, Message message);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var messages = await _sqs.GetMessagesAsync(GetQueueName(), stoppingToken);

                foreach (var message in messages)
                {
                    var messageType = message.MessageAttributes.GetMessageTypeAttributeValue();

                    try
                    {
                        await ProcessMessage(messageType, message);

                        await _sqs.DeleteMessageAsync(GetQueueName(), message.ReceiptHandle, stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error trying to process message of type {messageType} with error: {Message}.", messageType, ex.Message);
                        continue;
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }

        protected T DeserializeFromMessage<T>(Message message) where T : IMessage
            => JsonSerializer.Deserialize<T>(message.Body)!;

    }
}
