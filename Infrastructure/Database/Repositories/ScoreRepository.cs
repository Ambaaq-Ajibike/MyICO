namespace Infrastructure.Database.Repositories;

public class ScoreRepository : GenericRepository<Score>, IScoreRepository
{
    private readonly ApplicationContext _context;
    public ScoreRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}
