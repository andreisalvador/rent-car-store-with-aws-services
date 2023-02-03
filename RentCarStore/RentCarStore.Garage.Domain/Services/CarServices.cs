using FluentValidation;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Garage.Domain.Enums;
using RentCarStore.Garage.Domain.Repositories;
using RentCarStore.Garage.Domain.Services.Interfaces;

namespace RentCarStore.Garage.Domain.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _repository;
        private readonly INotifier _domainNotifier;
        private readonly IValidator<Car> _carValidator;
        public CarServices(ICarRepository repository, INotifier domainNotifier, IValidator<Car> carValidator)
        {
            _repository = repository;
            _domainNotifier = domainNotifier;
            _carValidator = carValidator;
        }


        public void AddAccessories(Car car, Accessories accessories)
        {
            if(Enum.IsDefined(accessories) && car is not null)
                car.AddAccessories(accessories);
        }

        public async Task AddCar(Car car)
        {
            var validationResult = await _carValidator.ValidateAsync(car);

            if (!validationResult.IsValid)
            {
                await _domainNotifier.Notify(new DomainNotification("add-car", validationResult.ToString()));
                return;
            }

            bool licensePlateExists = await _repository.ExistsCarWithLicensePlate(car.LicensePlate);

            if (licensePlateExists)
            {
                await _domainNotifier.Notify(new DomainNotification("add-car", "The license plate are exists."));
                return;
            }

            _repository.Add(car);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteCar(Guid carId)
        {
            var car = await GetCarById(carId);

            if(car is null)
            {
                await _domainNotifier.Notify(new DomainNotification("delete-car", $"The car with id '{carId}' doesn't exists."));
                return;
            }

            _repository.Delete(car);
            await _repository.SaveChangesAsync();
        }

        public Task<Car> GetCarById(Guid carId)
            => _repository.GetByIdAsync(carId);

        public async Task UpdateCar(Car car)
        {
            _repository.Update(car);
            await _repository.SaveChangesAsync();
        }
    }
}
