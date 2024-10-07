using BuberDinner.Contracts.ApiResponse;
using BuberDinner.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var exceptionHandler = exception as BuberException;

            // If the exception is a BuberException, then it is a handled exception
            if (exceptionHandler != null)
            {
                int statusCode = exceptionHandler.Status ?? (int)HttpStatusCode.InternalServerError;

                var apiError = new ApiErrorResponse(
                    statusCode,
                    new BuberDinner.Contracts.ErrorHandler.Error()
                    {
                        Code = exceptionHandler.Code,
                        Title = exceptionHandler.Message
                    }
                    );

                context.Result = new ObjectResult(apiError);
            }

            // If the exception is not a BuberException, then it is an unhandled exception
            else
            {
                var apiError = new ApiErrorResponse(
                    (int)HttpStatusCode.InternalServerError,
                    new BuberDinner.Contracts.ErrorHandler.Error()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace
                    }
                    );

                 context.Result = new ObjectResult(apiError);
            }

            context.ExceptionHandled = true;
        }
    }
}
