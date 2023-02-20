using Mapster;
using RentCarStore.Contracts.Application.Dtos;
using RentCarStore.Contracts.Application.Services.Interface;
using RentCarStore.Contracts.Domain;
using RentCarStore.Contracts.Domain.Services.Interfaces;

namespace RentCarStore.Contracts.Application.Services
{
    public class ContractApplicationService : IContractApplicationService
    {
        private readonly IContractService _domainService;

        public ContractApplicationService(IContractService domainService)
        {
            _domainService = domainService;
        }

        public async Task CreateContract(CreateContractRequestDto request)
        {
            Contract newContract = request.Adapt<Contract>();
            await _domainService.CreateContract(newContract);
        }
    }
}
