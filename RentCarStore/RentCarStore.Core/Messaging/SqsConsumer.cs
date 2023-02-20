using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Logging;
using RentCarStore.Core.Messaging.Interfaces;
using System.Net;

namespace RentCarStore.Core.Messaging
{
    public class SqsConsumer : ISqsConsumer
    {
        private readonly IAmazonSQS _sqs;
        private readonly ILogger<SqsConsumer> _logger;

        public SqsConsumer(IAmazonSQS sqs, ILogger<SqsConsumer> logger)
        {
            _sqs = sqs;
            _logger = logger;
        }

        public async Task<List<Message>> GetMessagesAsync(string queueName, CancellationToken cancellationToken = default!)
        {
            try
            {
                var queueUrlResponse = await GetQueueUrl(queueName);

                ReceiveMessageRequest request = new()
                {
                    QueueUrl = queueUrlResponse.QueueUrl,
                    MessageAttributeNames = new List<string> { "All" },
                    MaxNumberOfMessages = 5
                };

                var receiveMessageResponse = await _sqs.ReceiveMessageAsync(request, cancellationToken);

                if (receiveMessageResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    throw new AmazonSQSException($"Failed to GetMessagesAsync for queue {queueName}. Response: {receiveMessageResponse.HttpStatusCode}");
                }

                return receiveMessageResponse.Messages;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetMessagesAsync from queue {queueName}. Erro: {ex.Message}");
                throw;
            }
        }


        public async Task DeleteMessageAsync(string queueName, string receiptHandle, CancellationToken cancellationToken = default!)
        {
            var queueUrlResponse = await GetQueueUrl(queueName);

            try
            {
                var response = await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, receiptHandle, cancellationToken);

                if (response.HttpStatusCode != HttpStatusCode.OK)
                {
                    throw new AmazonSQSException($"Failed to DeleteMessageAsync with for [{receiptHandle}] from queue '{queueName}'. Response: {response.HttpStatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to DeleteMessageAsync from queue {queueName}. Erro: {ex.Message}");
                throw;
            }
        }

        private Task<GetQueueUrlResponse> GetQueueUrl(string queueName) => _sqs.GetQueueUrlAsync(queueName);
    }
}
