using Microsoft.EntityFrameworkCore;
using RentCarStore.Contracts.Domain;

namespace RentCarStore.Contracts.Data
{
    public class ContractContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }

        public ContractContext(DbContextOptions<ContractContext> optios) :base(optios) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContractContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
