using Enoca.Core.Common;
using Enoca.Core.Exceptions;
using Enoca.Core.Extensions;
using Enoca.Core.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Enoca.Api.Infrastructure
{
    /// <summary>
    /// This is the global excpetion filter for the solution
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var responseModel = context.Exception switch
            {
                BusinessLogicException logicException => ApiResponse<dynamic>.Failure(logicException.GetMessage()),
                ArgumentException argumentException => ApiResponse<dynamic>.Failure(argumentException.Message),
                FrameworkException logicException => ApiResponse<dynamic>.Failure(logicException.GetMessage()),
                _ => ApiResponse<dynamic>.Failure(_Common.GeneralError)
            };

            context.Result = new JsonResult(responseModel);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
