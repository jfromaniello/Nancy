namespace Nancy.ContentNegotiation.DefaultResponder
{
    using Responses;

    public class JsonResponder : IResponder
    {
        public bool CanRespond(Request request, object value)
        {
            return request.Accept("application/json") || request.Accept("text/json");
        }

        public Response CreateResponse(Request request, IResponseFormatter responseFormatter, object value)
        {
            return new JsonResponse(value.GetType(), value);
        }
    }
}