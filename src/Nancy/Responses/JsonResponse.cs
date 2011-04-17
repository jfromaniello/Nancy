namespace Nancy.Responses
{
    using System;
    using System.IO;
    using Nancy.Json;

    public class JsonResponse : Response
    {
        public JsonResponse(Type modelType, object model)
        {
            this.Contents = GetJsonContents(model);
            this.ContentType = "application/json";
            this.StatusCode = HttpStatusCode.OK;
        }

        private static Action<Stream> GetJsonContents(object model)
        {
            return stream =>
            {
                var serializer = new JavaScriptSerializer(null, false, JsonSettings.MaxJsonLength, JsonSettings.MaxRecursions);
                var json = serializer.Serialize(model);

                var writer = new StreamWriter(stream);

                writer.Write(json);
                writer.Flush();
            };
        }
    }
    public class JsonResponse<TModel> : JsonResponse
    {
        public JsonResponse(TModel model) : base(typeof(TModel), model)
        {}
    }
}