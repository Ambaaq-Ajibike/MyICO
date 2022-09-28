

namespace Application.Features.ContestantService.Commands.UpdateContestantProfile;

public class UpdateProfileRequestHandler : IRequestHandler<UpdateProfileRequest, BaseResponse>
{
    private readonly IContestantRepository _contestantRepository;

    public UpdateProfileRequestHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public Task<BaseResponse> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
    {
    //    var contestant = UpdateProfile(request.Model.name, request.Model.email, request.Model.password);
    //    await _contestantRepository.Create(contestant);
    //    return new RegisterContestantResponseModel("Contestant Successfully created", true);
    }
}
