namespace RentCarStore.Finance.Application.Dtos
{
    public record InvoiceDto
    {
        public Guid CardId { get; init; }
        public Guid CustomerId { get; init; }
        public DateTime StartRentAt { get; init; }
        public DateTime ReturnRentAt { get; init; }
    }
}
