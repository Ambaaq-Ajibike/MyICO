using Application.Features.GameService.Commands.CreateGame.Dto;
using FluentValidation;

namespace Application.Features.GameService.Commands.CreateGame.Validator;

public class CreateGameValidator : AbstractValidator<CreateGameRequestModel>
    {
        public CreateGameValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage("{PropertyName} must contain a value");
        }
    }