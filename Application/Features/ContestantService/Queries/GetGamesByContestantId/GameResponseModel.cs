namespace Application.Features.ContestantService.Queries.GetGamesByContestantId;

public record GameResponseModel(string message, bool status, IReadOnlyList<ResponseModel> responseModels = null) : BaseResponse(message, status);
