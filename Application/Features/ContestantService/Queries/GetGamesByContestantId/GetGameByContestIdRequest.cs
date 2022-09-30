namespace Application.Features.ContestantService.Queries.GetGamesByContestantId;

public record GetGameByContestIdRequest(string contestId) : IRequest<GameResponseModel>;

