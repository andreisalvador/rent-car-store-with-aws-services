using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarStore.Finance.Domain;

namespace RentCarStore.Finance.Data.Mapping
{
    public class PriceListMapping : IEntityTypeConfiguration<PriceList>
    {
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.IsActive);
        }
    }
}
