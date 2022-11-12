using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class GameRepository : GenericRepository<Game>, IGameRepository
{
    public GameRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Game> GetGameFullInformation(string id)
    {
        var game = await _context.Games.Include(x => x.ContestantGames).ThenInclude(x => x.Contestant).FirstOrDefaultAsync(x => x.Id.Equals(id));
        return game;
    }

    public async Task<IReadOnlyList<Contestant>> GetContestantsInAGame(string gameId)
    {
        var gameContestant = await _context.ContestantGames.Where(x => x.GameId.Equals(gameId)).Select(x => x.Contestant).ToListAsync();
        return gameContestant;
    }

    public async Task<IReadOnlyList<Game>> GetGamesByContestantId(string contestId)
    {
         var gameContestant = await _context.ContestantGames.Where(x => x.ContestantId.Equals(contestId)).Select(x => x.Game).ToListAsync();
        return gameContestant;
    }
}
