using Application.Features.GameService.Commands.CreateGame.Validator;
using Mapster;

namespace Application.Features.GameService.Commands.CreateGame;

public sealed class CreateRequestHandler : IRequestHandler<CreateGameRequest, BaseResponse>
{
    private readonly IGameRepository _gameRepository;
    public CreateRequestHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public async Task<BaseResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
    {
        var gameValidator = new CreateGameValidator();
        var validateGame = await gameValidator.ValidateAsync(request.model);
        if(!validateGame.IsValid) throw new ValidationException(validateGame);
        var game = new Game(request.model.Name, request.model.CreatedBy);
        var g = _gameRepository.Create(game);
        await _gameRepository.SaveDbChanges();
        return new BaseResponse("Game successfully created", true);
    }
}
