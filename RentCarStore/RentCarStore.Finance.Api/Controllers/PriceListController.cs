using Microsoft.AspNetCore.Mvc;
using RentCarStore.Finance.Application.Dtos;
using RentCarStore.Finance.Application.Services.Interfaces;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceListController : ControllerBase
    {
        private readonly IPriceListApplicationService _applicationService;
        private readonly IPriceListService _domainService;

        public PriceListController(IPriceListApplicationService applicationService, IPriceListService domainService)
        {
            _applicationService = applicationService;
            _domainService = domainService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePriceList(PriceListDto priceList)
        {
            await _applicationService.Create(priceList);
            return Ok();
        }

        [HttpPut]
        [Route("{priceListId}/inactivate")]
        public async Task<IActionResult> InactivatePriceList(Guid priceListId)
        {
            await _domainService.Inactivate(priceListId);
            return Ok();
        }

        [HttpPut]
        [Route("{priceListId}/activate")]
        public async Task<IActionResult> ActivatePriceList(Guid priceListId)
        {
            await _domainService.Activate(priceListId);
            return Ok();
        }
    }
}