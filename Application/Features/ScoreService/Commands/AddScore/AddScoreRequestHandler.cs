namespace Application.Features.ScoreService.Commands.AddScore;

public sealed class AddScoreRequestHandler : IRequestHandler<AddScoreRequest, BaseResponse>
{
    private readonly IScoreRepository _scoreRepository;

    public AddScoreRequestHandler(IScoreRepository scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    public async Task<BaseResponse> Handle(AddScoreRequest request, CancellationToken cancellationToken)
    {
        var score = new Score(request.scoreRequest.amount, request.scoreRequest.contestantId, request.scoreRequest.gameId);
        var addScore = await _scoreRepository.Create(score);
        return new BaseResponse("Score successfully added", false);
    }
}
