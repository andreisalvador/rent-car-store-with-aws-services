using Microsoft.AspNetCore.Mvc;
using RentCarStore.Contracts.Application.Dtos;
using RentCarStore.Contracts.Application.Services.Interface;

namespace RentCarStore.Contracts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {

        private readonly ILogger<ContractController> _logger;
        private readonly IContractApplicationService _appService;

        public ContractController(ILogger<ContractController> logger, IContractApplicationService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet(Name = "CreateContract")]
        public async Task<IActionResult> Post(CreateContractRequestDto request)
        {
            await _appService.CreateContract(request);
            return Ok();
        }
    }
}