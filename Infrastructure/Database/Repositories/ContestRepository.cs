
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Infrastructure.Database.Repositories;

public class ContestRepository : GenericRepository<Contestant>, IContestantRepository
{
    private readonly IConfiguration _config;
    private readonly ApplicationContext _context;
    public ContestRepository(IConfiguration configuration, ApplicationContext context) : base(configuration, context)
    {
        _config = configuration;
        _context = context;
    }
    public async Task<Contestant> GetAllContestantInformation(string id)
    {
        var contestants = _context.Contestants.Includes(x => x.Scores).FirstOrDefault(x => x.Id == id);
        if(contestants != null)
        {
            var game = _context.ContestantGames.Includes(x => x.Game).Where(x => x.ContestantId == id);
        }
    }
}
