namespace Infrastructure.Database.Repositories;

public class ScoreRepository : GenericRepository<Score>, IScoreRepository
{
    public ScoreRepository(ApplicationContext context)
    {
        _context = context;
    }
}
