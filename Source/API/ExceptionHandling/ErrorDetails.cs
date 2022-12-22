using System.Net;

namespace OCBManager.API.ExceptionHandling
{
    public record ErrorDetails(HttpStatusCode StatusCode, string Message);
}
