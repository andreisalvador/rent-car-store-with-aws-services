using FluentValidation;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Garage.Domain.Constants.Messaging;
using RentCarStore.Garage.Domain.Enums;
using RentCarStore.Garage.Domain.Messaging.Messages;
using RentCarStore.Garage.Domain.Repositories;
using RentCarStore.Garage.Domain.Services.Interfaces;

namespace RentCarStore.Garage.Domain.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _repository;
        private readonly INotifier _domainNotifier;
        private readonly IValidator<Car> _carValidator;
        private readonly ISnsPublisher _sns;
        public CarServices(ICarRepository repository, INotifier domainNotifier, IValidator<Car> carValidator, ISnsPublisher sns)
        {
            _repository = repository;
            _domainNotifier = domainNotifier;
            _carValidator = carValidator;
            _sns = sns;
        }


        public void AddAccessories(Car car, Accessories accessories)
        {
            if (Enum.IsDefined(accessories) && car is not null)
                car.AddAccessories(accessories);
        }

        public async Task AddCar(Car car)
        {
            var validationResult = await _carValidator.ValidateAsync(car);

            if (!validationResult.IsValid)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-car", validationResult.ToString()));
                return;
            }

            bool licensePlateExists = await _repository.ExistsCarWithLicensePlate(car.LicensePlate);

            if (licensePlateExists)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-car", "The license plate are exists."));
                return;
            }

            _repository.Add(car);
            await _repository.SaveChangesAsync();

            await _sns.PublishAsync("arn:aws:sns:us-east-1:000000000000:garage", new CarCreatedEvent
            {
                Id = car.Id,
                Category = car.Category,
                CurrentMileage = car.CurrentMileage,
                Accessories = car.Accessories
            });
        }

        public async Task Inactivate(Guid carId)
        {
            var car = await GetCarById(carId);

            if (car is null)
            {
                await _domainNotifier.Notify(DomainNotification.Create("inactivate-car", $"The car with id '{carId}' doesn't exists."));
                return;
            }

            car.Inactivate();
            await _repository.SaveChangesAsync();

            await _sns.PublishAsync("arn:aws:sns:us-east-1:000000000000:garage", new CarInactivatedEvent { Id = car.Id });
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
