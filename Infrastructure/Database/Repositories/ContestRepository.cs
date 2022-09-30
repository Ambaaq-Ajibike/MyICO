
namespace Infrastructure.Database.Repositories;

public class ContestRepository : GenericRepository<Contestant>, IContestantRepository
{
    public ContestRepository()
    {
        
    }

    public Task<Contestant> GetAllContestantInformation(int id)
    {
        throw new NotImplementedException();
    }
}
