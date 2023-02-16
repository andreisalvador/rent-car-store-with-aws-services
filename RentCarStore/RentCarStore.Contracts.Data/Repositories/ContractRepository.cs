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

        public Task<bool> IsCarAvailableInPeriod(Guid carId, DateTime withdrawDateAndTime)
            => DbSet.AnyAsync(_ => _.CarId == carId && _.WithdrawAt <= withdrawDateAndTime && _.ReturnAt >= withdrawDateAndTime
                                                    && (_.Status != Domain.Enums.ContractStatus.Finished || _.Status != Domain.Enums.ContractStatus.Denied));
    }
}
