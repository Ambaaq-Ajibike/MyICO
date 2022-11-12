
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ContestRepository : GenericRepository<Contestant>, IContestantRepository
{
    public ContestRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Contestant> GetAllContestantInformation(string id)
    {
        var contestants = await _context.Contestants.Include(x => x.Scores).Include(x => x.ContestantGames).FirstOrDefaultAsync(x => x.Id == id);
      return contestants;
    }
}
