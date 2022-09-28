using System.Net;

namespace Application.Common.Exeptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message) : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}
