using RentCarStore.Core.Data;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Repositories.Interfaces;

namespace RentCarStore.Finance.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(FinanceContext context) : base(context)
        {
        }
    }
}
