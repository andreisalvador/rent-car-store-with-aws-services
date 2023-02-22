using FluentValidation;
using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Domain.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Category)
                .IsInEnum();
        }
    }
}
