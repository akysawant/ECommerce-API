namespace ECommerce.API.Middlewares
{
    public class RequestLogiingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogiingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}
