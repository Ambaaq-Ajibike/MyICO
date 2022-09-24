using System.Net;
namespace Application.Common.Exeptions;

public class CustomeException : Exception
{
    public List<string>? ErrorMessages{ get; }
    public HttpStatusCode StatusCode{ get; }
    public CustomeException(string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        ErrorMessages = errors;
        StatusCode = statusCode;
    }
}
