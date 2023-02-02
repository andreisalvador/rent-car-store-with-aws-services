using Amazon.SimpleNotificationService.Model;

namespace RentCarStore.Core.Messaging.Helper
{
    public static class SnsMessageTypeAttribute
    {
        private const string AttributeName = "MessageType";

        public static string GetMessageTypeAttributeValue(this Dictionary<string, MessageAttributeValue> attributes)
            => attributes.SingleOrDefault(x => x.Key == AttributeName).Value.StringValue;

        public static Dictionary<string, MessageAttributeValue> CreateAttributes<T>() => CreateAttributes(typeof(T).Name);

        public static Dictionary<string, MessageAttributeValue> CreateAttributes(string messageType)
        {
            return new Dictionary<string, MessageAttributeValue>
            {
                {
                    AttributeName, new MessageAttributeValue
                    {
                        DataType = nameof(String),
                        StringValue = messageType
                    }
                }
            };
        }
    }
}
