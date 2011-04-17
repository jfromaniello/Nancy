namespace Nancy.ContentNegotiation
{
    using System.Collections.Generic;
    using DefaultResponders;

    public class ContentNegotiationDefaults
    {
        public ContentNegotiationDefaults()
        {
            Responders = new IResponder[]
                             {
                                 new XmlResponder(), 
                                 new JsonResponder()
                             };
            FallbackResponder = new XmlResponder();
        }

        public virtual IEnumerable<IResponder> Responders { get; private set; }

        public virtual IResponder FallbackResponder { get; private set; }
    }
}