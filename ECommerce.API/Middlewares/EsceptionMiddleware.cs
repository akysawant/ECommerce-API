using ECommerce.API.Common.Exceptions;
using ECommerce.API.Common.Response;
using System.Net;
using System.Text.Json;

namespace ECommerce.API.Middlewares
{
    public class EsceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public EsceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode;

            switch(exception)
            {
                case NotFoundException: statusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException: statusCode = StatusCodes.Status400BadRequest;
                    break;
                case UnauthorizedException: statusCode = StatusCodes.Status401Unauthorized;
                    break;
                default: statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }


            context.Response.StatusCode = statusCode;

            var response = ApiResponse<object>.FailureResponse(exception.Message);

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }

    }
}
