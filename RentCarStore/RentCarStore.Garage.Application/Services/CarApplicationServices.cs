using Mapster;
using RentCarStore.Garage.Application.Dtos;
using RentCarStore.Garage.Application.Services.Interfaces;
using RentCarStore.Garage.Data.Repositories.Interfaces;
using RentCarStore.Garage.Domain;

namespace RentCarStore.Garage.Application.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _carRepository;

        public CarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public CarDto AddCar(CarDto carDto)
        {
            Car car = carDto.Adapt<Car>();

            _carRepository.Add(car);
            _carRepository.SaveChangesAsync();

            return carDto;
        }
    }
}
