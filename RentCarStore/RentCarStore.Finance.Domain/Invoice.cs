using RentCarStore.Core.Entites;

namespace RentCarStore.Finance.Domain
{
    public class Invoice : Entity
    {
        public Guid CardId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartRentAt { get; set; }
        public DateTime ReturnRentAt { get; set; }
        public decimal Value { get; set; }

        public Invoice()
        {

        }

        public Invoice(Guid cardId, Guid customerId, DateTime startRentAt, DateTime returnRentAt)
        {
            CardId = cardId;
            CustomerId = customerId;
            StartRentAt = startRentAt;
            ReturnRentAt = returnRentAt;
            Value = CalculateInvoiceValue();
        }

        public decimal CalculateInvoiceValue()
        {
            throw new NotImplementedException();
        }
    }
}
