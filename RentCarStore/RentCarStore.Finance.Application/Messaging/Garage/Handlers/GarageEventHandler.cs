using Mapster;
using RentCarStore.Finance.Application.Messaging.Garage.Handlers.Interface;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Repositories.Interfaces;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Application.Messaging.Garage.Handlers
{
    public class GarageEventHandler : IGarageEventHandler
    {
        private readonly ICarService _domainService;
        private readonly ICarRepository _repository;

        public GarageEventHandler(ICarService domainService, ICarRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }

        public async Task Handle(CarCreatedEvent carCreatedEvent)
        {
            Car newCar = carCreatedEvent.Adapt<Car>();
            await _domainService.Create(newCar);
        }

        public async Task Handle(CarInactivatedEvent carInactivatedEvent)
        {
            Car car = await _repository.GetByIdAsync(carInactivatedEvent.Id);

            car.IsActive = false;

            await _domainService.Update(car);
        }
    }
}
