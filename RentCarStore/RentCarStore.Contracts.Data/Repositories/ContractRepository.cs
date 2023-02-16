using Microsoft.EntityFrameworkCore;
using RentCarStore.Contracts.Domain;
using RentCarStore.Contracts.Domain.Repositories;
using RentCarStore.Core.Data;

namespace RentCarStore.Contracts.Data.Repositories
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(DbContext context) : base(context)
        {
        }
    }
}
