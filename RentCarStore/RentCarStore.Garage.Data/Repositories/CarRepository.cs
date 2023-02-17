using Microsoft.EntityFrameworkCore;
using RentCarStore.Core.Data;
using RentCarStore.Garage.Domain;
using RentCarStore.Garage.Domain.Repositories;

namespace RentCarStore.Garage.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(GarageContext context) : base(context)
        {
        }

        public Task<bool> ExistsCarWithLicensePlate(string licensePlate)
            => DbSet.AnyAsync(_ => _.LicensePlate == licensePlate);
    }
}
