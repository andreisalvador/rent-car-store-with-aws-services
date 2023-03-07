using Amazon.SQS.Model;

namespace RentCarStore.Core.Messaging.Helper
{
    public class MessageAttribute
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public static implicit operator MessageAttributeValue(MessageAttribute attribute)
            => new() { DataType = attribute.Type, StringValue = attribute.Value };
    }
}
