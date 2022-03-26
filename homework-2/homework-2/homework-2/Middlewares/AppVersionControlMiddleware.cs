using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace homework_2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppVersionControlMiddleware
    {
        private readonly RequestDelegate _next;

        public AppVersionControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext,IConfiguration configuration)
        {
            try
            {
                if (httpContext.Request.Path == "/login" || httpContext.Request.Path == "/register")
                {
                    await _next(httpContext);
                }
                var currentVersion = new Version(configuration.GetValue<string>("AppVersion"));
                var requestVersion = new Version(httpContext.Request.Headers["AppVersion"]);
                var checkVersion = currentVersion.CompareTo(requestVersion);
                if (requestVersion != null)
                {
                    if (checkVersion < 0)
                    {
                        // return bad request çünkü request app versionu app versiyonundan büyük
                        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                    else
                    {
                        // büyük olmadığı durumlar
                        _next(httpContext);
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                string message = " App versiyon parametresi gerekli!!!";
                await HandleExceptionAsync(httpContext, e, message);
            }
            catch (ArgumentException e)
            {
                string message = " AppVersion parametresi hatalı girildi!!!";
                await HandleExceptionAsync(httpContext, e, message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,ex, ex.Message);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext,Exception exception,string message)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsync($"Internal Server Error! Detail : {message}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppVersionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppVersionControlMiddleware>();
        }
    }
}
