namespace Nancy.ContentNegotiation
{
    public static class ModuleExtensions
    {
        /// <summary>
        /// Create an automatic formated response for the given request and result value.
        /// </summary>
        /// <param name="module">Current module</param>
        /// <param name="value">Response content value</param>
        /// <returns>Formated response object</returns>
        public static Response AutoFormatContent(this NancyModule module, object value)
        {
            return module.ContentNegotiator.CreateResponse(module.Request, module.Response, value);
        }
    }
}