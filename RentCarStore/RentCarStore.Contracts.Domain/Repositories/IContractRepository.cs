using RentCarStore.Core.Data.Interfaces;

namespace RentCarStore.Contracts.Domain.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<bool> IsCarAvailableInPeriod(Guid carId, DateTime withdrawDateAndTime);
    }
}
