namespace Application.Dtos.GameDto;

public record GetGame(string name, ICollection<Contestant> Contestants);

