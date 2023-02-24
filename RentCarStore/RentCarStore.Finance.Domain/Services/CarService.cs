using FluentValidation;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Finance.Domain.Repositories.Interfaces;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Domain.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IValidator<Car> _validator;
        private readonly INotifier _domainNotifier;

        public CarService(ICarRepository repository, IValidator<Car> validator, INotifier domainNotifier)
        {
            _repository = repository;
            _validator = validator;
            _domainNotifier = domainNotifier;
        }

        public async Task Create(Car car)
        {
            var validationResult = await _validator.ValidateAsync(car);

            if (!validationResult.IsValid)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-car", validationResult.ToString()));
                return;
            }

            var carExists = await _repository.Exists(c => c.Id == car.Id);

            if(carExists)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-car", "Unable to create because the car already exists."));
                return;
            }

            _repository.Add(car);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(Car car)
        {
            var validationResult = await _validator.ValidateAsync(car);

            if (!validationResult.IsValid)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-car", validationResult.ToString()));
                return;
            }

            _repository.Update(car);
            await _repository.SaveChangesAsync();
        }
    }
}
