namespace RentCarStore.Contracts.Application.Dtos
{
    public record CreateContractRequestDto
    {
        public Guid CarId { get; set; }
        public DateTime WithdrawAt { get; set; }
        public DateTime ReturnAt { get; set; }
        public Guid CustomerId { get; set; }
    }
}
