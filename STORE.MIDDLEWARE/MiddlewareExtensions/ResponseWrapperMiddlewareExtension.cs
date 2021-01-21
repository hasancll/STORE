using Microsoft.AspNetCore.Builder;
using STORE.MIDDLEWARE.Middlewares;

namespace STORE.MIDDLEWARE.MiddlewareExtensions
{
    public static class ResponseWrapperMiddlewareExtension
    {
        public static void UseResponseWrapperMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ResponseWrapperMiddleware>();
        }
    }
}
