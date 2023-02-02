using Microsoft.EntityFrameworkCore;
using RentCarStore.Core.Data;
using RentCarStore.Garage.Data.Repositories.Interfaces;
using RentCarStore.Garage.Domain;

namespace RentCarStore.Garage.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext context) : base(context)
        {
        }
    }
}
