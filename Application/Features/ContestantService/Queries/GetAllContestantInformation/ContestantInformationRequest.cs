namespace Application.Features.ContestantService.Queries.GetAllContestantInformation;

public class ContestantInformationRequest : IRequest<ResponseModel>
{
    public string ContestantId{ get; set; }
}
