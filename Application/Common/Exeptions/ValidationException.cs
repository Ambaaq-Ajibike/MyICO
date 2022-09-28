

using System.Net;
using FluentValidation.Results;

namespace Application.Common.Exeptions;

public class ValidationException : CustomException
{
    public List<string> ValidationErrors{ get; set; } = new List<string>();
    public ValidationException(ValidationResult validationResult) : base("validation error", null, HttpStatusCode.NotAcceptable)
    {
        foreach (var error in validationResult.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }
}
