namespace Nancy.ContentNegotiation
{
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultContentNegotiator : IContentNegotiator
    {
        private readonly ContentNegotiationDefaults contentNegotiationDefaults;
        private readonly IEnumerable<IResponder> responders;

        public DefaultContentNegotiator(IEnumerable<IResponder> responders, ContentNegotiationDefaults contentNegotiationDefaults)
        {
            this.responders = responders;
            this.contentNegotiationDefaults = contentNegotiationDefaults;
        }

        public Response CreateResponse(Request request, IResponseFormatter responseFormatter, object value)
        {
            var responder = responders.Union(contentNegotiationDefaults.Responders)
                                .FirstOrDefault(r => r.CanRespond(request, value)) 
                                ?? contentNegotiationDefaults.FallbackResponder;

            return responder.CreateResponse(request, responseFormatter, value);
        }
    }
}