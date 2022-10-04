namespace Application.Features.ScoreService.Commands.AddScore;

public record AddScoreRequest(ScoreRequestModel scoreRequest) : IRequest<BaseResponse>;
