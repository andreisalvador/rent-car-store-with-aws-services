namespace RentCarStore.Finance.Domain.Services.Interfaces
{
    public interface ICarService
    {
        Task Create(Car car);
        Task Update(Car car);
    }
}
