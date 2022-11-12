using Application.Features.GameService.Commands.AddContestantToGame;
using Application.Features.GameService.Commands.CreateGame;
using Application.Features.GameService.Commands.CreateGame.Dto;
using Application.Features.GameService.Queries.GetAllContestantsOnAGame;
using Application.Features.GameService.Queries.GetGameInformation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
         private readonly IMediator _mediator;
         public GameController( IMediator mediator)
         {
                    _mediator = mediator;
         }
         [HttpPost("CreateGame")]
         public async Task<IActionResult> CreateGame([FromForm] CreateGameRequestModel model)
         {
                    var createGame = await _mediator.Send(new CreateGameRequest(
                              model
                    ));
                    return Ok(createGame);
         }
         [HttpPatch("AddContestantToGame/{gameId}")]
         public async Task<IActionResult> AddContestantToGame(List<string> contestantId, [FromRoute]string gameId)
         {
                    var createGame = await _mediator.Send(new AddContestantToGameRequest(
                              contestantId,
                              gameId
                    ));
                    return (createGame.status)  ? Ok(createGame) : BadRequest(createGame);
         }

         [HttpGet("GetGame/{gameId}")]
         public async Task<IActionResult> GetGame([FromRoute] string gameId)
         {
                    var createGame = await _mediator.Send(new GetGameRequest(
                              gameId
                    ));
                    return Ok(createGame);
         }
         [HttpGet("GetAllContestantInAGame")]
         public async Task<IActionResult> GetAllContestantInAGame([FromRoute] string gameId)
         {
                    var createGame = await _mediator.Send(new AllContestantRequest(
                              gameId
                    ));
                    return Ok(createGame);
         }
}
