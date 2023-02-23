using FluentValidation;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Finance.Domain.Repositories.Interfaces;
using RentCarStore.Finance.Domain.Services.Interfaces;

namespace RentCarStore.Finance.Domain.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPriceListRepository _priceListRepository;
        private readonly ICarRepository _carRepository;
        private readonly INotifier _domainNotifier;
        private readonly IValidator<Invoice> _invoiceValidator;

        public InvoiceService(IInvoiceRepository invoiceRepository, IPriceListRepository priceListRepository, INotifier domainNotifier, ICarRepository carRepository, IValidator<Invoice> invoiceValidator)
        {
            _invoiceRepository = invoiceRepository;
            _priceListRepository = priceListRepository;
            _domainNotifier = domainNotifier;
            _carRepository = carRepository;
            _invoiceValidator = invoiceValidator;
        }

        public async Task Add(Invoice invoice)
        {
            var validationResult = await _invoiceValidator.ValidateAsync(invoice);

            if(!validationResult.IsValid)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-invoice", validationResult.ToString()));
                return;
            }

            var car = await _carRepository.GetByIdAsync(invoice.CardId);

            if(car is null || !car.IsActive)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-invoice", "Unable to create invoice because the car wasn't found or it's inactive."));
                return;
            }

            PriceList priceList = await _priceListRepository.GetByCarCaterory(car.Category);

            if (priceList is null)
            {
                await _domainNotifier.Notify(DomainNotification.Create("add-invoice", "Unable to create invoice because there is no price list available for the category."));
                return;
            }

            invoice.SetValue(Invoice.CalculateInvoiceValue(invoice.StartRentAt, invoice.ReturnRentAt, priceList));

            _invoiceRepository.Add(invoice);
            await _invoiceRepository.SaveChangesAsync();
        }

        public async Task Cancel(Guid invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);

            if(invoice is null)
            {
                await _domainNotifier.Notify(DomainNotification.Create("cancel-invoice", "Unable to cancel invoice because it wasn't found into database."));
                return;
            }

            invoice.Cancel();
            await _invoiceRepository.SaveChangesAsync();
        }
    }
}
