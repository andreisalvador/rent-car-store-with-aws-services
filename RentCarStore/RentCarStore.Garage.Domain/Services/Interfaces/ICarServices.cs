using RentCarStore.Garage.Domain.Enums;

namespace RentCarStore.Garage.Domain.Services.Interfaces
{
    public interface ICarServices
    {
        void AddAccessories(Car car, Accessories accessories);
    }
}
