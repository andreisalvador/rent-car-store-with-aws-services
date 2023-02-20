using RentCarStore.Contracts.Application.Dtos;

namespace RentCarStore.Contracts.Application.Services.Interface
{
    public interface IContractApplicationService
    {
        public Task CreateContract(CreateContractRequestDto request);
    }
}
