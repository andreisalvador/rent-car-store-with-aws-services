using RentCarStore.Garage.Application.Dtos;
using RentCarStore.Garage.Application.Dtos.Car;

namespace RentCarStore.Garage.Application.Services.Interfaces
{
    public interface ICarApplicationServices
    {
        Task<CarDto> AddCar(CarDto carDto);
        Task<CarDto> UpdateCar(UpdateCarDto carDto);
        Task DeleteCar(Guid carId);
    }
}
