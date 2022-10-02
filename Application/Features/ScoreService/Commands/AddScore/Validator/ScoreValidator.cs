using FluentValidation;

namespace Application.Features.ScoreService.Commands.AddScore.Validator;

public class ScoreValidator : AbstractValidator<ScoreRequestModel>
{
    public ScoreValidator()
    {
        // RuleFor(x => x.amount).
    }
}
