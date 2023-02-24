using FluentValidation;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Finance.Domain.Repositories.Interfaces;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Domain.Services
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _repository;
        private readonly IValidator<PriceList> _validator;
        private readonly INotifier _domainNotifier;

        public PriceListService(IPriceListRepository repository, IValidator<PriceList> validator, INotifier domainNotifier)
        {
            _repository = repository;
            _validator = validator;
            _domainNotifier = domainNotifier;
        }

        public async Task Create(PriceList priceList)
        {
            var validationResult = await _validator.ValidateAsync(priceList);

            if(!validationResult.IsValid) 
            {
                await _domainNotifier.Notify(DomainNotification.Create("price-list-add", validationResult.ToString()));
                return;
            }

            if(priceList.Validity.Date < DateTime.Now.Date)
            {
                await _domainNotifier.Notify(DomainNotification.Create("price-list-add", "You can't create a price list with validity to the past."));
                return;
            }

            _repository.Add(priceList);
            await _repository.SaveChangesAsync();
        }

        public async Task Inactivate(Guid priceListId)
        {
            PriceList priceListToBeInactivated = await _repository.GetByIdAsync(priceListId);

            if(priceListToBeInactivated is null)
            {
                await _domainNotifier.Notify(DomainNotification.Create("price-list-inactivate", "Price list not found into database."));
                return;
            }

            priceListToBeInactivated.Inactivate();

            _repository.Update(priceListToBeInactivated);
            await _repository.SaveChangesAsync();
        }

        public async Task Activate(Guid priceListId)
        {
            PriceList priceListToBeInactivated = await _repository.GetByIdAsync(priceListId);

            if (priceListToBeInactivated is null)
            {
                await _domainNotifier.Notify(DomainNotification.Create("price-list-activate", "Price list not found into database."));
                return;
            }

            priceListToBeInactivated.Activate();

            _repository.Update(priceListToBeInactivated);
            await _repository.SaveChangesAsync();
        }
    }
}
