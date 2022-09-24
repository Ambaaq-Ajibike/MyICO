using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Contestant : BaseEntity
{
    public string Name{ get; private set; }
    public string Email{ get; private set; }
    public string Password{ get; private set; }
    public ICollection<ContestantGame> ContestantGames{ get; private set; }
    public ICollection<Score> Scores{ get; set; }
    public Contestant(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        Scores = new HashSet<Score>();
        ContestantGames = new HashSet<ContestantGame>();
    }
}
