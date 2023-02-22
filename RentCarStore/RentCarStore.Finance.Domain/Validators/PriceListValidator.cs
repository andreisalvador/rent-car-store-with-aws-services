using FluentValidation;

namespace RentCarStore.Finance.Domain.Validators
{
    public class PriceListValidator : AbstractValidator<PriceList>
    {
        public PriceListValidator()
        {
            RuleFor(p => p.Category)
                .IsInEnum();

            RuleFor(p => p.Validity)
                .NotEmpty()
                .NotEqual(DateTime.MinValue);

            RuleFor(p => p.ValuePerHour)
                .GreaterThan(0);
        }
    }
}
