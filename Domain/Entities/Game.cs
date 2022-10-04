using System;
using Domain.Enums;

namespace Domain.Entities;

public class Game : BaseEntity
{
    public string Name{get; private set;}
    public string CreatedBy{get; private set;}
    public int? EndedBy{get; private set;}
    public DateTime? EndedOn{get; private set; }
    public DateTime CreatedOn{get; private set; }
    public GameStatus GameStatus{ get; private set; }
    public ICollection<ContestantGame> ContestantGames{ get; private set; }
    public Game(string name, string createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
        CreatedOn = DateTime.UtcNow;
        GameStatus = GameStatus.Created;
    }
    public Game AddContestantsToGame(List<Contestant> contestants)
    {
        foreach (var item in contestants)
        {
            var contestantGame = new ContestantGame(item.Id, item, this.Id, this);
            ContestantGames.Add(contestantGame);
        }
        return this;
    }
    public Game EndGame(int endedBy)
    {
        EndedBy = endedBy;
        GameStatus = GameStatus.Active;
        EndedOn = DateTime.UtcNow;
        return this;
    }
    public Game StartGame()
    {
        GameStatus = GameStatus.Active;
        return this;
    }
}
