using System;
using System.Net;
using System.Threading.Tasks;
using Core.Extensions.ResponseModel;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

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
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


            string message = "Internal Server Error";
            //Validation Hatalarının error kısmını döndüreceğiz


            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;

                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    StatusCode = 400,
                    Message = message,
                    ValidateErrors = ((ValidationException)e).Errors

                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message

            }.ToString());
        }
    }
}