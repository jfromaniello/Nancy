namespace Nancy.ContentNegotiation.DefaultResponders
{
    using Nancy.Responses;

    public class XmlResponder : IResponder
    {
        #region IFormatSelector Members

        public bool CanRespond(Request request, object value)
        {
            return request.Accept("application/xml") || request.Accept("text/xml");
        }

        public Response CreateResponse(Request request, IResponseFormatter responseFormatter, object value)
        {
            return new XmlResponse(value.GetType(), value, "application/xml");
        }

        #endregion
    }
}