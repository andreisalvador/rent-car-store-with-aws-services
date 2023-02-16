using FluentValidation;
using RentCarStore.Contracts.Domain.Repositories;
using RentCarStore.Contracts.Domain.Services.Interfaces;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;

namespace RentCarStore.Contracts.Domain.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IValidator<Contract> _validator;
        private readonly INotifier _domainNotifier;

        public ContractService(IContractRepository contractRepository, INotifier domainNotifier, IValidator<Contract> validator)
        {
            _contractRepository = contractRepository;
            _domainNotifier = domainNotifier;
            _validator = validator;
        }

        public async Task CreateContract(Contract contract)
        {
            var validationResult = await _validator.ValidateAsync(contract);

            if (!validationResult.IsValid)
            {
                await _domainNotifier.Notify(new DomainNotification("add-contract", validationResult.ToString()));
                return;
            }

            _contractRepository.Add(contract);
            await _contractRepository.SaveChangesAsync();
        }
    }
}
