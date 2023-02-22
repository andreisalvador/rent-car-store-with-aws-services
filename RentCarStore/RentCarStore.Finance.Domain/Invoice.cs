using RentCarStore.Core.Entites;
using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Domain
{
    public class Invoice : Entity
    {
        public Guid CardId { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime StartRentAt { get; private set; }
        public DateTime ReturnRentAt { get; private set; }
        public InvoiceStatus Status { get; private set; }
        public decimal Value { get; private set; }

        public Invoice()
        {

        }

        public Invoice(Guid cardId, Guid customerId, DateTime startRentAt, DateTime returnRentAt)
        {
            CardId = cardId;
            CustomerId = customerId;
            StartRentAt = startRentAt;
            ReturnRentAt = returnRentAt;
            Status = InvoiceStatus.PaymentPending;
        }

        public void SetValue(decimal value)
        {
            if (Status == InvoiceStatus.PaymentPending)
                Value = value;
        }


        public void Payed()
           => Status = InvoiceStatus.Payed;

        public void Cancel()
            => Status = InvoiceStatus.Cancelled;

        public static decimal CalculateInvoiceValue(DateTime startRentAt, DateTime ReturntRentAt, PriceList priceList)
            => priceList.GetValueFromPeriod(startRentAt, ReturntRentAt);
    }
}
