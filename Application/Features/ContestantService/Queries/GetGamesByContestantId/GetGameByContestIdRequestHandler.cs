using Mapster;

namespace Application.Features.ContestantService.Queries.GetGamesByContestantId;

public sealed class GetGameByContestIdRequestHandler : IRequestHandler<GetGameByContestIdRequest, GameResponseModel>
{
    private readonly IGameRepository _gameRepository;

    public GetGameByContestIdRequestHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<GameResponseModel> Handle(GetGameByContestIdRequest request, CancellationToken cancellationToken)
    {
        var games = await _gameRepository.GetGamesByContestantId(request.contestId);
        if(games.Count() == 0) return new GameResponseModel("This participant have not participated in any game yet", true);
        var responseModel = games.Adapt<IReadOnlyList<ResponseModel>>();
        return new GameResponseModel("List of games", true, responseModel);
    }
}
