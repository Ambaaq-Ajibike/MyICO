namespace Application.Features.ScoreService.Commands.AddScore;

public record ScoreRequestModel(int amount, string contestantId, string gameId);
