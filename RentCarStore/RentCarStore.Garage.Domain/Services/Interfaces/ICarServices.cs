namespace RentCarStore.Garage.Domain.Services.Interfaces
{
    public interface ICarServices
    {
        Task AddCar(Car car);
        Task UpdateCar(Car car);
        Task Inactivate(Guid carId);
        Task<Car> GetCarById(Guid carId);
    }
}
