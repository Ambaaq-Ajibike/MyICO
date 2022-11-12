using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.GameService.Commands.CreateGame;

namespace Application.Features.GameService.Commands.AddContestantToGame
{
          public class AddContestantToGameRequestHandler : IRequestHandler<AddContestantToGameRequest, BaseResponse>
          {
                private readonly IGameRepository _gameRepository;
                private readonly IContestantRepository _contestantRepository;
                public AddContestantToGameRequestHandler(IGameRepository gameRepository, IContestantRepository contestantRepository)
                {
                    _contestantRepository = contestantRepository;
                    _gameRepository = gameRepository;
                }
                    public async Task<BaseResponse> Handle(AddContestantToGameRequest request, CancellationToken cancellationToken)
                    {
                        List<Contestant> contestants = new List<Contestant>();
                        foreach (var item in request.contestantId)
                        {
                             var contestant = await _contestantRepository.Get(x => x.Id == item);
                           if(contestant is null) return new BaseResponse($"contestant with id {item} haven't registered", false);
                           contestants.Add(contestant);
                        }

                        var game = await _gameRepository.Get(x => x.Id == request.gameId);
                        if(game is null) return new BaseResponse($"Game with id {request.gameId}", false);

                        var gameContestant = game.AddContestantsToGame(contestants);
                        await _gameRepository.Update(game);
                        await _gameRepository.SaveDbChanges();
                        return new BaseResponse($"Contestant Successfully added to game", true);
                    }
          }
}