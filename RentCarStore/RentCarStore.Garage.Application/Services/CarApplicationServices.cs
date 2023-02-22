using Mapster;
using RentCarStore.Garage.Application.Dtos;
using RentCarStore.Garage.Application.Dtos.Car;
using RentCarStore.Garage.Application.Services.Interfaces;
using RentCarStore.Garage.Domain;
using RentCarStore.Garage.Domain.Services.Interfaces;

namespace RentCarStore.Garage.Application.Services
{
    public class CarApplicationServices : ICarApplicationServices
    {
        private readonly ICarServices _domainServices;

        public CarApplicationServices(ICarServices domainServices)
        {
            _domainServices = domainServices;
        }

        public async Task<CarDto> AddCar(CarDto carDto)
        {
            Car newCar = carDto.Adapt<Car>();
            await _domainServices.AddCar(newCar);
            return carDto;
        }

        public async Task<CarDto> UpdateCar(UpdateCarDto carDto)
        {
            Car car = carDto.Adapt<Car>();
            await _domainServices.UpdateCar(car);
            return carDto;
        }

        public async Task DeleteCar(Guid carId)
            => await _domainServices.Inactivate(carId);
    }
}
