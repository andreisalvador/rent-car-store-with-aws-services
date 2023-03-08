using RentCarStore.Finance.Application.Dtos;
using RentCarStore.Finance.Application.Messaging.Contracts.Handlers.Interfaces;
using RentCarStore.Finance.Application.Services.Interfaces;

namespace RentCarStore.Finance.Application.Messaging.Contracts.Handlers
{
    public class ContractsEventHandler : IContractsEventHandler
    {
        private readonly IInvoiceApplicationService _invoiceApplicationService;

        public ContractsEventHandler(IInvoiceApplicationService invoiceApplicationService)
        {
            _invoiceApplicationService = invoiceApplicationService;
        }

        public async Task Handle(ContractCreatedEvent contractCreatedEvent)
        {
            InvoiceDto newInvoice = new()
            {
                CardId = contractCreatedEvent.CarId,
                CustomerId = contractCreatedEvent.CustomerId,
                ReturnRentAt = contractCreatedEvent.ReturnAt,
                StartRentAt = contractCreatedEvent.WithdrawAt
            };

            await _invoiceApplicationService.Create(newInvoice);
        }
    }
}
