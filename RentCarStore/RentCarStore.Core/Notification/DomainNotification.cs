using MediatR;

namespace RentCarStore.Core.Notification
{
    public class DomainNotification : INotification
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }

        public static DomainNotification Create(string key, string value)
            => new(key, value);
    }
}
