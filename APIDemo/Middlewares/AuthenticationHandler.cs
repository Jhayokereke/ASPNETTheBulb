using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIDemo.Middlewares
{
    public class AuthenticationHandler
    {
        private readonly RequestDelegate _next;

        public AuthenticationHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";

                var response = new { success = false, message = "Request does not contain an ApiKey" };
                string json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
                return;
            }

            var data = extractedApiKey.ToString().Split("|");

            if (data[0] != "thebulb" || int.Parse(data[1]) > 225 || data[2] != true.ToString() )
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";

                var response = new { success = false, message = "Not a valid user" };
                string json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
                return;
            }

            await _next(context);
        }
    }
}
