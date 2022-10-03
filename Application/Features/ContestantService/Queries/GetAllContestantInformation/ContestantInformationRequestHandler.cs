using Mapster;

namespace Application.Features.ContestantService.Queries.GetAllContestantInformation;

public class ContestantInformationRequestHandler : IRequestHandler<ContestantInformationRequest, ResponseModel>
{
    private readonly IContestantRepository _contestantRepository;
public ContestantInformationRequestHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<ResponseModel> Handle(ContestantInformationRequest request, CancellationToken cancellationToken)
    {
        var contestant = await _contestantRepository.Get($"SELECT * FROM Contestants WHERE Id = {request.ContestantId}");
        if (contestant == null) throw new CustomException("Contest not found", null, HttpStatusCode.NotFound);
        return contestant.Adapt<ResponseModel>();
    }
}
