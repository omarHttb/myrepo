using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var Response = _env.IsDevelopment()
                 ? new ApiExeption((int)HttpStatusCode.InternalServerError,ex.Message, ex.StackTrace.ToString())
                 : new ApiExeption((int)HttpStatusCode.InternalServerError);

                 var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                 var json = JsonSerializer.Serialize(Response);

                 await context.Response.WriteAsync(json);
            }
        }
        
    }
}