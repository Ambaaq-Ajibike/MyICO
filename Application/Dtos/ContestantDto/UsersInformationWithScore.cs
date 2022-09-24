namespace Application.Dtos.ContestantDto;

public record UsersInformationWithScore(int score, int id, string name, string email) : ContestantInformationDto(id, name, email);

