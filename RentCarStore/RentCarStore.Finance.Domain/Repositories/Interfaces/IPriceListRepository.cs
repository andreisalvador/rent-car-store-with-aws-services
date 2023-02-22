using RentCarStore.Core.Data.Interfaces;
using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Domain.Repositories.Interfaces
{
    public interface IPriceListRepository : IRepository<PriceList>
    {
        Task<PriceList> GetByCarCaterory(CarCategory category);
    }
}
