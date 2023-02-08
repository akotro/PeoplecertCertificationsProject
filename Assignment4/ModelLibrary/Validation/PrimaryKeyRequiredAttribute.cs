using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ModelLibrary.Validation;

public class PrimaryKeyRequiredAttribute : RequiredAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var httpContext = (HttpContext?)validationContext.GetService(typeof(IHttpContextAccessor));
        if (httpContext?.Request.Method != "POST" && value == null)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
