namespace RentCarStore.Garage.Domain.Services.Interfaces
{
    public interface ICarServices
    {
        Task AddCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(Guid carId);
        Task<Car> GetCarById(Guid carId);
    }
}
