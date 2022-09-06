using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Model.DTOs;

namespace Sat.Recruitment.Api.ExceptionHandler
{
    public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<UnhandledExceptionFilterAttribute> _logger;

        public UnhandledExceptionFilterAttribute(ILogger<UnhandledExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }


        public override void OnException(ExceptionContext context)
        {
            var result = new ResultDTO()
            {
                IsSuccess = false,
                Message = "An error occurred while processing your request.",
                StatusCode = 500
            };

            // Log the exception
            _logger.LogError("=====================UNHANDLED EXCEPTION=====================");
            _logger.LogError("=============================================================");
            _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);
            _logger.LogError("CLASS: {class}", context.Exception.TargetSite.DeclaringType);
            _logger.LogError("METHOD: {method}", context.ActionDescriptor.DisplayName);
            _logger.LogError("STACK TRACE: {stackTrace}", context.Exception.StackTrace);
            _logger.LogError("======================END UNHANDLED EXCEPTION================");
            // Set the result
            context.Result = new ObjectResult(result)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}