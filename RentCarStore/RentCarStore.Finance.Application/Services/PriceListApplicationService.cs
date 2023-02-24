using Mapster;
using RentCarStore.Finance.Application.Dtos;
using RentCarStore.Finance.Application.Services.Interfaces;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Application.Services
{
    public class PriceListApplicationService : IPriceListApplicationService
    {
        private readonly IPriceListService _domainService;

        public PriceListApplicationService(IPriceListService domainService)
        {
            _domainService = domainService;
        }

        public async Task Create(PriceListDto priceList)
        {
            PriceList newPriceList = priceList.Adapt<PriceList>();

            await _domainService.Create(newPriceList);
        }
    }
}
