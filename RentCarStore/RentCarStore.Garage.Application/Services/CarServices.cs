using RentCarStore.Garage.Data.Repositories.Interfaces;
using RentCarStore.Garage.Domain;
using RentCarStore.Garage.Domain.Services;

namespace RentCarStore.Garage.Application.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _carRepository;

        public CarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Car AddCar(Car car)
        {
            _carRepository.Add(car);
            _carRepository.SaveChangesAsync();

            return car;
        }
    }
}
