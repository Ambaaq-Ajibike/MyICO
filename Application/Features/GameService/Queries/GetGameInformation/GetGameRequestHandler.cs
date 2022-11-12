using Mapster;

namespace Application.Features.GameService.Queries.GetGameInformation;

public sealed class GetGameRequestHandler : IRequestHandler<GetGameRequest, ResponseModel>
{
    private readonly IGameRepository _gameRepository;

    public GetGameRequestHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ResponseModel> Handle(GetGameRequest request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameFullInformation(request.gameId);
        if(game == null) return new ResponseModel("Game with this id does not exist", false);
        return game.Adapt<ResponseModel>();
    }
}
