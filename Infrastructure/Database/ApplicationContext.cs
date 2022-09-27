using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Score>()
        .HasOne<Contestant>(x => x.Contestant)
        .WithMany(y => y.Scores)
        .HasForeignKey(f => f.Id);

        modelBuilder.Entity<ContestantGame>()
        .HasOne<Game>()
        .WithMany(x => x.ContestantGames)
        .HasForeignKey(x => x.Id);
    }
    public DbSet<Contestant> Contestants{ get; set; }
    public DbSet<ContestantGame> ContestantGames{ get; set; }
    public DbSet<Score> Scores{ get; set; }
    public DbSet<Game> Games{ get; set; }
}
