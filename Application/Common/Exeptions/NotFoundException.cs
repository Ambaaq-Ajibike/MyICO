using System.Net;

namespace Application.Common.Exeptions;

public class NotFoundException : CustomeException
{
    public NotFoundException(string message) : base(message, null, HttpStatusCode.NotFound)
    {

    }
}
