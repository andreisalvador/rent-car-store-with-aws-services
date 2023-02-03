using RentCarStore.Garage.Application.Dtos;

namespace RentCarStore.Garage.Application.Services.Interfaces
{
    public interface ICarApplicationServices
    {
        Task<CarDto> AddCar(CarDto carDto);
        Task<CarDto> UpdateCar(CarDto carDto);
    }
}
