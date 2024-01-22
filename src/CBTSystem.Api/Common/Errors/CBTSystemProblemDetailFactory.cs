using System.Diagnostics;
using CBTSystem.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace CBTSystem.Api.Common.Errors;
public class CBTSystemProblemDetailFactory(IOptions<ApiBehaviorOptions> options) : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options=options?.Value?? throw new ArgumentException(nameof(options));
    
    public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, 
        string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            statusCode??=500;
            var problemDetails=new ProblemDetails{
                Status=statusCode,
                Detail=detail,
                Title=title,
                Type=type,
                Instance=instance
            };
            if(title is not null)
            {
                problemDetails.Title=title;
            }
            ApplyProblemDetailsDefaults(httpContext,problemDetails,statusCode.Value);
            return problemDetails;
        }


    public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, 
    ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, 
    string? detail = null, string? instance = null)
    {
        statusCode??=StatusCodes.Status400BadRequest;
        var validationProblemDetails=new ValidationProblemDetails{
           Status=statusCode.Value,
            Type=type,
            Detail=detail,
            Instance=instance,

        };
        if(validationProblemDetails.Title is not null)
        {
            validationProblemDetails.Title=title;
        }
        return validationProblemDetails;
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext,ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status??=statusCode;
        if(_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title??=clientErrorData.Title;
            problemDetails.Type??=clientErrorData.Link;
        }
        var traceId=Activity.Current?.Id??httpContext?.TraceIdentifier;
        if(traceId!=null)
        {
            problemDetails.Extensions["traceId"]=traceId;
        }
        var errors=httpContext?.Items[HttpContextKeys.Errors] as List<Error>;
        if(errors is not null)
        {
            problemDetails.Extensions[HttpContextKeys.Errors]=errors;
        }
        problemDetails.Extensions.Add("errorCodes",errors?.Select(e=>e.Code));
    }
}