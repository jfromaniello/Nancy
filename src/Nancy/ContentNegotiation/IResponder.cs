using System;

namespace Nancy.ContentNegotiation
{
    public interface IResponder
    {
        bool CanRespond(Request request, object value);
        Response CreateResponse(Request request, IResponseFormatter responseFormatter, object value);
    }
}