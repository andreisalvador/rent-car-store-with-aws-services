using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarStore.Garage.Domain;

namespace RentCarStore.Garage.Data.Mappings
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.LicensePlate).IsUnique();
            builder.HasIndex(x => x.ChassisNumber).IsUnique();
        }
    }
}
