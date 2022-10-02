namespace Application.Features.GameService.Queries.GetGameInformation;

public record GetGameRequest(string gameId) : IRequest<ResponseModel>;

