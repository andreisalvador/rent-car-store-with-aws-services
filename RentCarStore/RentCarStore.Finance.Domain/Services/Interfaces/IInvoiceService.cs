namespace RentCarStore.Finance.Domain.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task Create(Invoice invoice);
        Task Cancel(Guid invoiceId);
    }
}
