namespace Domain.Entities;

public class Score : BaseEntity
{
    public int Amount{get; private set;}
    public string ContestantId{get; private set;}
    public Contestant Contestant{get; private set;}
    public Score(int amount, string contestantId)
    {
        Amount = amount;
        ContestantId = contestantId;
    }
}
