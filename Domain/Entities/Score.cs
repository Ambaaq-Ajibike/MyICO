namespace Domain.Entities;

public class Score : BaseEntity
{
    public int Amount{get; private set;}
    public string ContestantId{get; private set;}
    public Contestant Contestant{get; private set;}
    public string GameId{ get; set; }
    public Score(int amount, string contestantId, string gameId)
    {
        Amount = amount;
        ContestantId = contestantId;
        GameId = gameId;
    }
}
