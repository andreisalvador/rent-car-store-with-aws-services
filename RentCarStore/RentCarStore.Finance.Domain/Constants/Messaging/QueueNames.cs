namespace RentCarStore.Finance.Domain.Constants.Messaging
{
    public static class QueueNames
    {
        public const string CONTRACT_FINANCE_QUEUE = "contract.finance";
        public const string CONTRACT_FINANCE_QUEUE_DLQ = "contract.finance.dlq";
        public const string GARAGE_FINANCE_QUEUE = "garage.finance";
        public const string GARAGE_FINANCE_QUEUE_DLQ = "garage.finance.dlq";
    }
}
