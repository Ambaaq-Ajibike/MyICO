namespace Infrastructure.Database.Repositories;

public class GameRepository : GenericRepository<Game>, IGameRepository
{
    public Task<Game> GetGameFullInformation(string id)
    {
        throw new NotImplementedException();
    }

    Task<Contestant> IGameRepository.GetContestantsInAGame(string gameId)
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<Game>> IGameRepository.GetGamesByContestantId(string contestId)
    {
        throw new NotImplementedException();
    }
}
