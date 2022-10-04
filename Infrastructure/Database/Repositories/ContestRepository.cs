
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Infrastructure.Database.Repositories;

public class ContestRepository : GenericRepository<Contestant>, IContestantRepository
{
    private readonly ApplicationContext _context;
    public ContestRepository(ApplicationContext context) : base( context)
    {
        _context = context;
    }
    public async Task<Contestant> GetAllContestantInformation(string id)
    {
        var contestants = await _context.Contestants.Include(x => x.Scores).Include(x => x.ContestantGames).FirstOrDefaultAsync(x => x.Id == id);
      return contestants;
    }
}
