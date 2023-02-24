using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Application.Dtos
{
    public record PriceListDto
    {
        public string Name { get; init; }
        public CarCategory Category { get; init; }
        public DateTime Validity { get; init; }
        public decimal ValuePerHour { get; init; }
    }
}
