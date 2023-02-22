using FluentValidation;

namespace RentCarStore.Finance.Domain.Validators
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(i => i.CardId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(i => i.CustomerId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(i => i.StartRentAt)
                .NotEmpty()
                .NotEqual(DateTime.MinValue);

            RuleFor(i => i.ReturnRentAt)
               .NotEmpty()
               .NotEqual(DateTime.MinValue);
        }
    }
}
