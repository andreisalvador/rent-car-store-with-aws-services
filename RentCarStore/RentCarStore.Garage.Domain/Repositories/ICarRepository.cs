using RentCarStore.Core.Data.Interfaces;

namespace RentCarStore.Garage.Domain.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<bool> ExistsCarWithLicensePlate(string licensePlate);
    }
}
