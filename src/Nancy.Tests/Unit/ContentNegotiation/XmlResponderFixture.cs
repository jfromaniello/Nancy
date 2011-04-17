namespace Nancy.Tests.Unit.ContentNegotiation
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using FakeItEasy;
    using Nancy.ContentNegotiation.DefaultResponders;
    using Nancy.IO;
    using Xunit;

    public class XmlResponderFixture
    {
        [Fact]
        public void Should_report_true_when_request_accept_app_xml()
        {
            var request = BuildRequestWithAccept("application/xml, image/png");
            var xmlResponder = new XmlResponder();
            xmlResponder.CanRespond(request, typeof(string)).ShouldBeTrue();
        }

        [Fact]
        public void Should_report_true_when_request_accept_text_xml()
        {
            var request = BuildRequestWithAccept("text/xml, image/png");
            var xmlResponder = new XmlResponder();
            xmlResponder.CanRespond(request, typeof(string)).ShouldBeTrue();
        }

        [Fact]
        public void Should_report_false_when_request_accept_non_xml_content()
        {
            var request = BuildRequestWithAccept("text/json, image/png");
            var xmlResponder = new XmlResponder();
            xmlResponder.CanRespond(request, typeof(string)).ShouldBeFalse();
        }

        [Fact]
        public void Should_return_xml_response()
        {
            var request = BuildRequestWithAccept("application/xml, image/png");
            var xmlResponder = new XmlResponder();
            var response = xmlResponder.CreateResponse(request, A.Fake<IResponseFormatter>(),
                                             new TestModel {IntProperty = 1, StringProperty = "abc"});

            
            
            using(var ms = new MemoryStream())
            {
                response.Contents(ms);
                ms.Position = 0;
                var xmlSerializer = new XmlSerializer(typeof(TestModel));
                var model = (TestModel) xmlSerializer.Deserialize(ms);

                model.IntProperty.ShouldEqual(1);
                model.StringProperty.ShouldEqual("abc");
            }
            
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
