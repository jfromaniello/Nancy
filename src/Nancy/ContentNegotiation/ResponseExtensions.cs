using System.Linq;

namespace Nancy.ContentNegotiation
{
    public static class ResponseExtensions
    {
        public static bool Accept(this Request request, string contentType)
        {
            return request.Headers.ContainsKey("Accept")
                   && request.Headers["Accept"].Any(c => c.Contains(contentType));
        }
    }
}