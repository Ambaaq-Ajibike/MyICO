using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace Application.Features.GameService.Queries.GetAllContestantsOnAGame
{
    public class AllContestantRequestHandler : IRequestHandler<AllContestantRequest, ResponseModel>
    {
        private readonly IGameRepository _gameRepository;
        public AllContestantRequestHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<ResponseModel> Handle(AllContestantRequest request, CancellationToken cancellationToken)
        {
            var contestant = await _gameRepository.GetContestantsInAGame(request.GameId);
            if (contestant == null) throw new CustomException("Contest not found", null, HttpStatusCode.NotFound);
            return contestant.Adapt<ResponseModel>();
        }
    }
}