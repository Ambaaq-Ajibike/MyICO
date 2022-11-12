using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.GameService.Commands.AddContestantToGame
{
    public record AddContestantToGameRequest(List<string> contestantId, string gameId) : IRequest<BaseResponse>;
 
}