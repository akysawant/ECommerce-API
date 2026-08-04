namespace ECommerce.API.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isKeyPresent = context.Request.Headers.TryGetValue(
                "X-API-KEY",
                out var apiKey);

            if(!isKeyPresent)
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync(
                    "API key is missing");

                return;
            }

            await _next(context);
        }
    }
}
