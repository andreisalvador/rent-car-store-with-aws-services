using RentCarStore.Core.Data;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Repositories.Interfaces;

namespace RentCarStore.Finance.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(FinanceContext context) : base(context)
        {
        }
    }
}
