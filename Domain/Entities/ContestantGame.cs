namespace Domain.Entities;

public class ContestantGame : BaseEntity
{
    public string ContestantId{ get; private set; }
    public Contestant Contestant{ get; private set; }
    public string GameId{ get; private set; }
    public Game Game{ get; private set; }
    public ContestantGame(string contestantId, Contestant contestant, string gameId, Game game)
    {
        ContestantId = contestantId;
        Contestant = contestant;
        GameId = gameId;
        Game = game;
    }
}
