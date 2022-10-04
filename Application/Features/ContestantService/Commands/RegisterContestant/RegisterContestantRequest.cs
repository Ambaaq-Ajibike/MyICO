using Application.Features.ContestantService.Commands.RegisterContestant.Dto;

namespace Application.Features.ContestantService.Commands.RegisterContestant;

public class RegisterContestantRequest : IRequest<RegisterContestantResponseModel>
{
    public RegisterContestantRequestModel Model { get; set; }
}

