using FluentValidation;
using RentCarStore.Contracts.Domain.Constants.Messaging;
using RentCarStore.Contracts.Domain.Messaging.Messages;
using RentCarStore.Contracts.Domain.Repositories;
using RentCarStore.Contracts.Domain.Services.Interfaces;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;

namespace RentCarStore.Contracts.Domain.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IValidator<Contract> _validator;
        private readonly INotifier _domainNotifier;
        private readonly ISnsPublisher _sns;

        public ContractService(IContractRepository contractRepository, INotifier domainNotifier, IValidator<Contract> validator, ISnsPublisher sns)
        {
            _contractRepository = contractRepository;
            _domainNotifier = domainNotifier;
            _validator = validator;
            _sns = sns;
        }

        public async Task CreateContract(Contract contract)
        {
            var validationResult = await _validator.ValidateAsync(contract);

            if (!validationResult.IsValid)
            {
                await _domainNotifier.Notify(new DomainNotification("add-contract", validationResult.ToString()));
                return;
            }

            var isCarAvailable = await _contractRepository.IsCarAvailableInPeriod(contract.CarId, contract.WithdrawAt);

            if (!isCarAvailable)
            {
                await _domainNotifier.Notify(new DomainNotification("add-contract", "The car is not available in the period."));
                return;
            }

            _contractRepository.Add(contract);
            await _contractRepository.SaveChangesAsync();

            _ = await _sns.PublishAsync(RouterKeys.CONTRACT_TOPIC, new ContractCreatedEvent
            {
                Id = contract.Id,
                CarId = contract.CarId,
                Code = contract.Code,
                CustomerId = contract.CustomerId,
                ReturnAt = contract.ReturnAt,
                WithdrawAt = contract.WithdrawAt
            });
        }


        public async Task CancelContract(Guid contractId)
        {
            Contract contract = await _contractRepository.GetByIdAsync(contractId);

            if (contract is null)
            {
                await _domainNotifier.Notify(DomainNotification.Create("cancel-contract", "Unable to cancel contract because it wasn't found into database."));
                return;
            }

            contract.Cancel();
            await _contractRepository.SaveChangesAsync();
        }
    }
}
