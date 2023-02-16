namespace RentCarStore.Garage.Application.Dtos.Car
{
    public record UpdateCarDto : CarDto
    {
        public Guid Id { get; set; }
    }
}
