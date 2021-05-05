using Microsoft.AspNetCore.Builder;
using STORE.MIDDLEWARE.Middlewares;
using System;
using System.Collections.Generic;
using System.Text;

namespace STORE.MIDDLEWARE.MiddlewareExtensions
{
    public static class ExceptionMiddleWareExtension
    {
        public static void UseExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseStatusCodeMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CheckStatusMiddleware>();
        }
    }
}
