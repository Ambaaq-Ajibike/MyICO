
using Application.Features.ContestantService.Commands.RegisterContestant.Dto;
using FluentValidation;

namespace Application.Features.ContestantService.Commands.RegisterContestant.Validator
{
    public class RegisterContestantValidator : AbstractValidator<RegisterContestantRequestModel>
    {
        public RegisterContestantValidator()
        {
            var specialCharacters = "!@#$%^&*?/><.,|";
            var capitalLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            RuleFor(r => r.name).NotEmpty().NotNull().WithMessage("{PropertyName} must contain a value");
            RuleFor(r => r.email).Must(x => x.Contains('@')).WithMessage("{PropertyName} is not valid email");
            RuleFor(c => c.password).MinimumLength(5).WithMessage("Password length must be greater than 5");
            RuleFor(c => c.password).Must(c => c.Intersect(specialCharacters).Count() >= 1).WithMessage("Password must contains at least one special character");
            RuleFor(c => c.password).Must(c => c.Intersect(capitalLetter).Count() >= 1).WithMessage("Password must contains at least one capital letter");
        }
    }
}