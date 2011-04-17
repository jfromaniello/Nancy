namespace Nancy.Tests.Unit.ContentNegotiation
{
    using System.Collections.Generic;
    using System.IO;
    using FakeItEasy;
    using Nancy.ContentNegotiation;
    using Nancy.ContentNegotiation.DefaultResponder;
    using Nancy.IO;
    using Nancy.Responses;
    using Xunit;

    public class JsonResponderFixture
    {
        [Fact]
        public void Should_report_true_when_request_accept_app_json()
        {
            var request = BuildRequestWithAccept("application/json, image/png");
            var xmlResponder = new JsonResponder();
            xmlResponder.CanRespond(request, typeof(string)).ShouldBeTrue();
        }

        [Fact]
        public void Should_report_true_when_request_accept_text_json()
        {
            var request = BuildRequestWithAccept("text/json, image/png");
            var xmlResponder = new JsonResponder();
            xmlResponder.CanRespond(request, typeof(string)).ShouldBeTrue();
        }

        [Fact]
        public void Should_report_false_when_request_accept_non_json_content()
        {
            var request = BuildRequestWithAccept("text/xml, image/png");
            var xmlResponder = new JsonResponder();
            xmlResponder.CanRespond(request, typeof(string)).ShouldBeFalse();
        }

        [Fact]
        public void Should_return_xml_response()
        {
            var request = BuildRequestWithAccept("application/json, image/png");
            var xmlResponder = new JsonResponder();
            var response = xmlResponder.CreateResponse(request, A.Fake<IResponseFormatter>(),
                                             new TestModel { IntProperty = 1, StringProperty = "abc" });

            response.ShouldBeOfType<JsonResponse>();
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

        public class TestModel
        {
            public string StringProperty { get; set; }
            public int IntProperty { get; set; }
        }

    }
}