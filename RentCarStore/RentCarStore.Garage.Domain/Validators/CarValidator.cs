using FluentValidation;

namespace RentCarStore.Garage.Domain.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Color)
               .NotEmpty()
               .NotNull();

            RuleFor(c => c.Label)
               .NotEmpty()
               .NotNull();

            RuleFor(c => c.Description)
               .NotEmpty()
               .NotNull();

            RuleFor(c => c.LicensePlate)
               .NotEmpty()
               .NotNull()
               .MinimumLength(6);

            RuleFor(c => c.ChassisNumber)
               .NotEmpty()
               .NotNull()
               .MinimumLength(7);

            RuleFor(c => c.CurrentMileage)
               .GreaterThanOrEqualTo(uint.MinValue);

            RuleFor(c => c.Type)
                .IsInEnum();

            RuleFor(c => c.BuildDate)
                .NotEmpty()
                .NotEqual(DateOnly.MinValue)
                .Must(date => date.Year > 1900);

            RuleFor(c => c.Accessories)
                .IsInEnum();
        }
    }
}
