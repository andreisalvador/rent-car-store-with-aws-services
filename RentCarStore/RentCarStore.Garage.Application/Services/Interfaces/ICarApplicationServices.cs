using RentCarStore.Garage.Application.Dtos;

namespace RentCarStore.Garage.Application.Services.Interfaces
{
    public interface ICarApplicationServices
    {
        CarDto AddCar(CarDto car);
    }
}
