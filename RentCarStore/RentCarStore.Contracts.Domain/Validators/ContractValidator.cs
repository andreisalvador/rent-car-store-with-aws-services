using FluentValidation;

namespace RentCarStore.Contracts.Domain.Validators
{
    public class ContractValidator : AbstractValidator<Contract>
    {
        public ContractValidator()
        {
            RuleFor(x => x.CarId)
                .NotEqual(Guid.Empty)
                .NotEmpty();

            RuleFor(x => x.WithdrawAt)
                .NotEmpty()
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.ReturnAt)
               .NotEmpty()
               .NotEqual(DateTime.MinValue);
        }
    }
}
