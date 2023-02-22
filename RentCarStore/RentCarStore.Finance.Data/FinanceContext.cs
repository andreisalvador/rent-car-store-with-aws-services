using Microsoft.EntityFrameworkCore;
using RentCarStore.Finance.Data.Mapping;
using RentCarStore.Finance.Domain;

namespace RentCarStore.Finance.Data
{
    public class FinanceContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Car> Cars { get; set; }

        public FinanceContext(DbContextOptions<FinanceContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}