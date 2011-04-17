namespace Nancy.ContentNegotiation
{
    public interface IContentNegotiator
    {
        Response CreateResponse(Request request, IResponseFormatter responseFormatter, object value);
    }
}