using System;
namespace Domain.Entities;

public class Game : BaseEntity
{
    public string Name{get; private set;}
    public int CreatedBy{get; private set;}
    public int? EndedBy{get; private set;}
    public DateTime? EndedOn{get; private set; }
    public DateTime CreatedOn{get; private set; }
    public ICollection<ContestantGame> ContestantGames{ get; private set; }
    public Game(string name, int createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
        CreatedOn = DateTime.UtcNow;
        ContestantGames = new HashSet<ContestantGame>();
    }
    public void EndGame(int endedBy)
    {
        EndedBy = endedBy;
        EndedOn = DateTime.UtcNow;
    }
}
