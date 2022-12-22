using System.Net;

namespace OCBManager.API.ExceptionHandling
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            var details = new ErrorDetails(HttpStatusCode.InternalServerError, e.Message);
            httpContext.Response.StatusCode = (int)details.StatusCode;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsJsonAsync(details);
        }
    }
}