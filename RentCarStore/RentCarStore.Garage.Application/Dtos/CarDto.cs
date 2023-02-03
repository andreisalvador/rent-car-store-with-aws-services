using RentCarStore.Garage.Domain.Enums;

namespace RentCarStore.Garage.Application.Dtos
{
    public record CarDto
    {
        public string Label { get; init; }
        public string Color { get; init; }
        public string Name { get; init; }
        public CarType Type { get; init; }
        public Accessories Accessories { get; init; }
        public DateOnly BuildDate { get; init; }
        public uint CurrentMileage { get; init; }
        public string Description { get; init; }
        public string LicensePlate { get; init; }
        public string ChassisNumber { get; init; }
    }
}
