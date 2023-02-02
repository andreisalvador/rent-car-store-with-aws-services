using Microsoft.EntityFrameworkCore;
using RentCarStore.Garage.Data.Mappings;
using RentCarStore.Garage.Domain;

namespace RentCarStore.Garage.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}