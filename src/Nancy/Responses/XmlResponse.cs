namespace Nancy.Responses
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlResponse : Response
    {
        public XmlResponse(Type modelType, object model, string contentType)
        {
            this.Contents = GetXmlContents(modelType, model);
            this.ContentType = contentType;
            this.StatusCode = HttpStatusCode.OK;
        }

        private static Action<Stream> GetXmlContents(Type modelType, object model)
        {
            return stream =>
            {
                var serializer = new XmlSerializer(modelType);
                serializer.Serialize(stream, model);
            };
        }
    }
    public class XmlResponse<TModel> : XmlResponse
    {
        public XmlResponse(TModel model, string contentType)
            : base(typeof(TModel), model, contentType)
        {}
    }
}