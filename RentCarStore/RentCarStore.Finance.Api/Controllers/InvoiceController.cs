using Microsoft.AspNetCore.Mvc;
using RentCarStore.Finance.Application.Dtos;
using RentCarStore.Finance.Application.Services.Interfaces;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceApplicationService _applicationService;
        private readonly IInvoiceService _domainService;

        public InvoiceController(IInvoiceApplicationService applicationService, IInvoiceService domainService)
        {
            _applicationService = applicationService;
            _domainService = domainService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceDto invoice)
        {
            await _applicationService.Create(invoice);
            return Ok();
        }

        [HttpPut]
        [Route("{invoiceId}/cancel")]
        public async Task<IActionResult> Cancel(Guid invoiceId)
        {
            await _domainService.Cancel(invoiceId);
            return Ok();
        }
    }
}
