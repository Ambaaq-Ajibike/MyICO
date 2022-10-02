using Mapster;

namespace Application.Features.ContestantService.Queries.GetContestantInformation;

public class GetContestantInformationRequestHandler : IRequestHandler<GetContestantInformationRequest, ResponseModel>
{
    private readonly IContestantRepository _contestantRepository;

    public GetContestantInformationRequestHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<ResponseModel> Handle(GetContestantInformationRequest request, CancellationToken cancellationToken)
    {
        var contestant = await _contestantRepository.Get(x => x.Id == request.id);
        if(contestant == null) throw new CustomException("Contest not found", null, HttpStatusCode.NotFound);
        return contestant.Adapt<ResponseModel>();
    }
}
