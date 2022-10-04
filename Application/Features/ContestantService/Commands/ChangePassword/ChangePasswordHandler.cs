namespace Application.Features.ContestantService.Commands.ChangePassword;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, BaseResponse>
{
    private readonly IContestantRepository _contestantRepository;

    public ChangePasswordHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<BaseResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var getContestant = await _contestantRepository.Get(x => x.Id.Equals(request.Id));
        if(getContestant == null) throw new CustomException("User not found", null, HttpStatusCode.NotFound);

       var contestant = new Contestant();
       var passwordChange = contestant.ChangePassword(request.Password, getContestant);
       await _contestantRepository.Update(passwordChange);
       return new BaseResponse("Password Successfully changed", true);
    }
}
