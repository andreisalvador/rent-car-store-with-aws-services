using RentCarStore.Finance.Application.Dtos;

namespace RentCarStore.Finance.Application.Services.Interfaces
{
    public interface IInvoiceApplicationService
    {
        Task Create(InvoiceDto invoice);
    }
}
