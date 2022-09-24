namespace Domain.Entities;

public class ContestantGame : BaseEntity
{
    public string ContestantId{ get; set; }
    public Contestant Contestant{ get; set; }
    public string GameId{ get; set; }
    public Game Game{ get; set; }
}
