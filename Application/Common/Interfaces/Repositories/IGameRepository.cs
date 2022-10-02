namespace Application.Common.Interfaces.Repositories;

public interface IGameRepository: IRepository<Game>
{
    Task<Contestant> GetContestantsInAGame(string gameId);
    Task<IReadOnlyList<Game>> GetGamesByContestantId(string contestId);
    Task<Game> GetGameFullInformation(string id);
}
