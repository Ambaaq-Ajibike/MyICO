namespace Application.Features.ContestantService.Queries.GetContestantInformation;

public class GetContestantInformationRequest : IRequest<ResponseModel>
{
    public string id{ get; set; }
}
