namespace RentCarStore.Finance.Domain.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task Add(Invoice invoice);
        Task Cancel(Guid invoiceId);
    }
}
