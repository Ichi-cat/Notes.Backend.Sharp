using Microsoft.AspNetCore.Builder;

namespace Notes.Api.Middlewares
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this 
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionsHandlerMiddleware>();
        }
    }
}
