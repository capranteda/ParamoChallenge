using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Model.DTOs;

namespace Sat.Recruitment.Api.ExceptionHandler
{
    public class ValidationFilter: ActionFilterAttribute
    {
        private readonly ILogger<ValidationFilter> _logger;

        public ValidationFilter(ILogger<ValidationFilter> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //log error
                _logger.LogError("Invalid model state for the request");
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var result = new ResultDTO
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Message = "Validation errors",
                    Errors = errors.ToArray()
                };
                
                context.Result = new BadRequestObjectResult(result);
            }
        }
    }
}