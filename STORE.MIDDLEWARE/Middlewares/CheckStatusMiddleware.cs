using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using STORE.MIDDLEWARE.StoreResponseHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STORE.MIDDLEWARE.Middlewares
{
    public class CheckStatusMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckStatusMiddleware(RequestDelegate request)
        {
            _next = request;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next.Invoke(httpContext).ConfigureAwait(false);

            var statusCode = httpContext.Response.StatusCode;

            if (statusCode == 401)
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(StoreResponse.GetStoreResponseModelTry(true, statusCode.ToString(), "Lütfen giriş yapınız"))).ConfigureAwait(false);
            }
                
            if (statusCode == 404)
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(StoreResponse.GetStoreResponseModelTry(true, statusCode.ToString(), "Yetkiniz yok."))).ConfigureAwait(false);
            }
        }
    }
}
