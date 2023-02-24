using RentCarStore.Finance.Application.Dtos;

namespace RentCarStore.Finance.Application.Services.Interfaces
{
    public interface IPriceListApplicationService
    {
        Task Create(PriceListDto priceList);
    }
}
