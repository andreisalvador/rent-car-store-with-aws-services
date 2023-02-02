using RentCarStore.Garage.Application.Dtos;

namespace RentCarStore.Garage.Application.Services.Interfaces
{
    public interface ICarServices
    {
        CarDto AddCar(CarDto car);
    }
}
