using Mapster;
using RentCarStore.Finance.Application.Dtos;
using RentCarStore.Finance.Application.Services.Interfaces;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Application.Services
{
    public class InvoiceApplicationService : IInvoiceApplicationService
    {
        private readonly IInvoiceService _domainService;

        public InvoiceApplicationService(IInvoiceService domainService)
        {
            _domainService = domainService;
        }

        public async Task Create(InvoiceDto invoice)
        {
            Invoice newInvoice = invoice.Adapt<Invoice>();
            await _domainService.Create(newInvoice);
        }
    }
}
