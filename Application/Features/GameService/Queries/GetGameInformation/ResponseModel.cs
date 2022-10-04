namespace Application.Features.GameService.Queries.GetGameInformation;

public record ResponseModel(string message, bool status, IReadOnlyList<ContestantGame> contestantGames = null, string name = "", string createdOn = "", string endedOn = "") : BaseResponse(message, status);

