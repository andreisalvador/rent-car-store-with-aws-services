namespace RentCarStore.Finance.Domain.Services.Interfaces
{
    public interface IPriceListService
    {
        Task Create(PriceList priceList);
        Task Inactivate(Guid priceListId);
        Task Activate(Guid priceListId);
    }
}
