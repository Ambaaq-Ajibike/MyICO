using System.Net;

namespace Application.Common.Exeptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message, null, HttpStatusCode.NotFound)
    {

    }
}
