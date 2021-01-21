using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using STORE.MIDDLEWARE.StoreResponseHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace STORE.MIDDLEWARE.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        public RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var currentBody = httpContext.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                httpContext.Response.Body = memoryStream;

                await _next.Invoke(httpContext).ConfigureAwait(false);

                httpContext.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);
                var readToEnd = new StreamReader(memoryStream).ReadToEnd();

                object objResult = JsonConvert.DeserializeObject(readToEnd);

                var message = "";
                if (httpContext.Items["message"] != null)
                {
                    message = httpContext.Items["message"].ToString();
                }

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(StoreResponse.GetStoreResponseModelTry(true, "200", message, objResult))).ConfigureAwait(false);
            }
        }
    }
}
