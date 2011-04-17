namespace Nancy.Demo.ContentNegotiation
{
    using System.Xml.Serialization;
    using Nancy.ContentNegotiation;
    using Responses;

    public class CustomResponder : IResponder
    {
        public const string MyCompanyMediaType = "application/vnd.MyCompany.xml";

        public bool CanRespond(Request request, object value)
        {

            return request.Accept(MyCompanyMediaType) 
                   && value.GetType().Equals(typeof (TestModel));
        }

        public Response CreateResponse(Request request, IResponseFormatter responseFormatter, object value)
        {
            var casted = (TestModel) value;
            var alternativeModel = new AlternativeModel {Name = casted.FirstName, LastName = casted.LastName};
            return new XmlResponse<AlternativeModel>(alternativeModel, MyCompanyMediaType);
        }

        [XmlRoot(ElementName = "Person")]
        public class AlternativeModel
        {
            public string Name { get; set; }
            public string LastName { get; set; }
        }
    }
}