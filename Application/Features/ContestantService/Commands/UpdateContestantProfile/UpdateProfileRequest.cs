using Application.Features.ContestantService.Commands.UpdateContestantProfile.Dto;

namespace Application.Features.ContestantService.Commands.UpdateContestantProfile;

public class UpdateProfileRequest : IRequest<BaseResponse>
{
    public UpdateProfileRequestModel UpdateModel{ get; set; }
}
