using FluentValidation;

namespace DemoFluentValidation.Model
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required")
                .MaximumLength(10).WithMessage("Username cannot over than 10 characters");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email format not match");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match with password");
                }
            });

        }
    }
}
