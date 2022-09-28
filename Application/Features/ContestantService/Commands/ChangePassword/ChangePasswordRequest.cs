namespace Application.Features.ContestantService.Commands.ChangePassword;

public class ChangePasswordRequest : IRequest<BaseResponse>
{
    public string Id{ get; set; }
    public string Password{ get; set; }
}
