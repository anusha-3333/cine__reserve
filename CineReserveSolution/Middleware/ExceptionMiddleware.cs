using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                context.Response.StatusCode =
                    (int)HttpStatusCode.BadRequest;

                var result = JsonSerializer.Serialize(new
                {
                    error = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}