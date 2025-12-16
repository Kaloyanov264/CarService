using CarService.Models.Requests;
using FluentValidation;

namespace CarService.Host.Validators
{
    public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1).WithMessage("Name cannot be below 1 character.")
                .WithMessage("Name is required.");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3).WithMessage("Email cannot be below 3 characters.")
                .WithMessage("Email is required.");
        }
    }
}
