using RentCarStore.Garage.Domain.Enums;
using RentCarStore.Garage.Domain.Services.Interfaces;

namespace RentCarStore.Garage.Domain.Services
{
    public class CarServices : ICarServices
    {
        public void AddAccessories(Car car, Accessories accessories)
        {
            if(Enum.IsDefined(accessories) && car is not null)
                car.AddAccessories(accessories);
        }
    }
}
