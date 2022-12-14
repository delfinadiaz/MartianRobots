using MartianRobots.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MartianRobots.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await _handleExceptionAsync(httpContext, ex);
            }
        }

        private Task _handleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string result = JsonConvert.SerializeObject(new ErrorDetails {  ErrorMessage = exception.Message, ErrorType = "Failure"});

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new ErrorValidationDetails
                    {
                        ErrorMessage = exception.Message,
                        ErrorType = "Failure",
                        Errors = validationException.Errors
                    });
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;

                default:
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }

    public class ErrorDetails
    { 
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }

    }

    public class ErrorValidationDetails : ErrorDetails
    {
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
