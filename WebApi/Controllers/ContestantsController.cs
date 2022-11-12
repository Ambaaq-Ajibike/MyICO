using Application.Features.ContestantService.Commands.ChangePassword;
using Application.Features.ContestantService.Commands.RegisterContestant;
using Application.Features.ContestantService.Commands.RegisterContestant.Dto;
using Application.Features.ContestantService.Commands.UpdateContestantProfile;
using Application.Features.ContestantService.Commands.UpdateContestantProfile.Dto;
using Application.Features.ContestantService.Queries.GetAllContestantInformation;
using Application.Features.ContestantService.Queries.GetContestantInformation;
using Application.Features.ContestantService.Queries.GetGamesByContestantId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContestantsController : ControllerBase
{
          private readonly IMediator _mediator;
          public ContestantsController(IMediator mediator)
          {
                    _mediator = mediator;
          }
          [HttpPost("RegisterContestant")]
          public async  Task<IActionResult> RegisterContestant([FromForm] RegisterContestantRequestModel requestModel)
          {
                    var contestant = await _mediator.Send(new RegisterContestantRequest{Model = requestModel});
                    return Ok(contestant);
          }
          [HttpPatch("ChangePassword/{id}/{password}")]
          public async Task<IActionResult> ChangePassword([FromRoute] string id, [FromRoute] string password)
          {
                    var c = await _mediator.Send(new ChangePasswordRequest{
                              Id = id,
                              Password = password
                    });
                    return (c.status) ? Ok(c):BadRequest(c);
          }
          [HttpPut("UpdateProfile")]
          public async Task<IActionResult> UpdateProfile([FromForm]UpdateProfileRequestModel updateRequest)
          {
                    var c = await _mediator.Send(new UpdateProfileRequest{
                              UpdateModel = updateRequest
                    });
                    return (c.status) ? Ok(c):BadRequest(c);
          }
          [HttpGet("GetContestantFullDetails/{contestantId}")]
          public async Task<IActionResult> GetContestantFullDetails([FromRoute]string contestantId)
          {
                    var c = await _mediator.Send(new ContestantInformationRequest{
                              ContestantId = contestantId
                    });
                    return Ok(c);
          }

          [HttpGet("GetContestant/{contestantId}")]
          public async Task<IActionResult> GetContestant([FromRoute]string contestantId)
          {
                    var c = await _mediator.Send(new GetContestantInformationRequest{
                              id = contestantId
                    });
                    return Ok(c);
          }

          [HttpGet("GetGameByContestantId/{contestantId}")]
          public async Task<IActionResult> GetGameByContestantId([FromRoute]string contestantId)
          {
                    var c = await _mediator.Send(new GetGameByContestIdRequest(
                             contestantId
                    ));
                    return Ok(c);
          }
}
