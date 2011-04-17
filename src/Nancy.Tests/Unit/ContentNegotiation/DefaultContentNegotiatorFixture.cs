namespace Nancy.Tests.Unit.ContentNegotiation
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using FakeItEasy;
    using Nancy.ContentNegotiation;
    using Nancy.IO;
    using Xunit;

    public class DefaultContentNegotiatorFixture
    {
        [Fact]
        public void Should_use_first_responder_by_default()
        {
            var request = BuildRequestWithAccept("application/xml");
            var contentNegotiator = new DefaultContentNegotiator(Enumerable.Empty<IResponder>(), new ContentNegotiationDefaults());
            var response = contentNegotiator.CreateResponse(request, A.Fake<IResponseFormatter>(), new object());
            response.ContentType.ShouldEqual("application/xml");
        }

        [Fact]
        public void Should_use_fallback_responder_when_there_is_no_responder_for_such_request()
        {
            var request = BuildRequestWithAccept("application/pdf");
            var contentNegotiator = new DefaultContentNegotiator(Enumerable.Empty<IResponder>(), new ContentNegotiationDefaults());
            var response = contentNegotiator.CreateResponse(request, A.Fake<IResponseFormatter>() ,new object());
            response.ContentType.ShouldEqual("application/xml");
        }

        private static Request BuildRequestWithAccept(string acceptedContent)
        {
            var headers = new Dictionary<string, IEnumerable<string>>
                              {
                                  {"Accept", new[] {acceptedContent}}
                              };
            return new Request("GET", "http://www.google.com", headers,
                               RequestStream.FromStream(new MemoryStream()), "foo", "bar");
        }
    }
}