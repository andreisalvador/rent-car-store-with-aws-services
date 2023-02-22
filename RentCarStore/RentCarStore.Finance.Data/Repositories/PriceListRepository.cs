using Microsoft.EntityFrameworkCore;
using RentCarStore.Core.Data;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Enums;
using RentCarStore.Finance.Domain.Repositories.Interfaces;

namespace RentCarStore.Finance.Data.Repositories
{
    internal class PriceListRepository : Repository<PriceList>, IPriceListRepository
    {
        public PriceListRepository(FinanceContext context) : base(context)
        {
        }

        public Task<PriceList> GetByCarCaterory(CarCategory category)
            => DbSet.FirstOrDefaultAsync(p => p.Category == category && p.Validity >= DateOnly.FromDateTime(DateTime.Now));
    }
}
