namespace RentCarStore.Finance.Application.Messaging.Garage.Handlers.Interface
{
    public interface IGarageEventHandler
    {
        Task Handle(CarCreatedEvent carCreatedEvent);
        Task Handle(CarInactivatedEvent carCreatedEvent);
    }
}
