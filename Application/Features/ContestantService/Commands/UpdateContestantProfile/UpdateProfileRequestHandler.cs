



using Application.Features.ContestantService.Commands.UpdateContestantProfile.Validator;

namespace Application.Features.ContestantService.Commands.UpdateContestantProfile;

public class UpdateProfileRequestHandler : IRequestHandler<UpdateProfileRequest, BaseResponse>
{
    private readonly IContestantRepository _contestantRepository;

    public UpdateProfileRequestHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<BaseResponse> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProfileValidator();

        var validate = await validator.ValidateAsync(request.UpdateModel);
        if(!validate.IsValid) throw new ValidationException(validate);

        var getContestant = await _contestantRepository.Get(x => x.Id == request.UpdateModel.id);

        if(getContestant == null) throw new CustomException("User not found", null, HttpStatusCode.NotFound);

        var contestant = new Contestant();

       var updateContestant = contestant.UpdateProfile(request.UpdateModel.name, request.UpdateModel.mail, getContestant);

       await _contestantRepository.Update(updateContestant);

       return new BaseResponse("Profile Successfully updated", true);
    }
}
