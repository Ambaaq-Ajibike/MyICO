using Application.Features.ContestantService.Commands.UpdateContestantProfile.Dto;
using FluentValidation;

namespace Application.Features.ContestantService.Commands.UpdateContestantProfile.Validator;

public class UpdateProfileValidator : AbstractValidator<UpdateProfileRequestModel>
{
    public UpdateProfileValidator()
    {
        RuleFor(r => r.name).NotEmpty().NotNull().WithMessage("{PropertyName} must contain a value");
        RuleFor(r => r.mail).Must(x => x.Contains('@')).WithMessage("{PropertyName} is not valid email");
    }
}
