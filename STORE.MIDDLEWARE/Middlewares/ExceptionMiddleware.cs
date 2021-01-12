using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using STORE.EXCEPTION;
using STORE.MIDDLEWARE.StoreResponseHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STORE.MIDDLEWARE.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                String errorMessage = "";

                if (ex is StoreApiException)
                {
                    errorMessage = ex.Message;
                }

                var response = StoreResponse.GetStoreResponseModel(false, "400", errorMessage);

                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(response).ConfigureAwait(false);
            }
        }
    }
}
