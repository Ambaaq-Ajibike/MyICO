namespace Application.Features.ContestantService.Queries.GetAllContestantInformation;

public record ResponseModel(string Name, string Email, List<GameResponse> Game);

