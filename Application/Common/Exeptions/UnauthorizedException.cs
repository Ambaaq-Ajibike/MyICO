using System.Net;

namespace Application.Common.Exeptions;

public class UnauthorizedException : CustomeException
{
    public UnauthorizedException(string message) : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}
