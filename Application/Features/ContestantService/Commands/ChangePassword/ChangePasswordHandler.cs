namespace Application.Features.ContestantService.Commands.ChangePassword;

public sealed class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, BaseResponse>
{
    private readonly IContestantRepository _contestantRepository;

    public ChangePasswordHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<BaseResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var getContestant = await _contestantRepository.Get(x => x.Id.Equals(request.Id));
        if(getContestant == null)  return new BaseResponse("Contestants not found", false);

       var contestant = new Contestant();
       var passwordChange = contestant.ChangePassword(request.Password, getContestant);
       await _contestantRepository.Update(passwordChange);
       await _contestantRepository.SaveDbChanges();
       return new BaseResponse("Password Successfully changed", true);
    }
}
