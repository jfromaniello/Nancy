namespace Nancy.Demo.ContentNegotiation
{
    using Nancy.ContentNegotiation;

    public class TestModule : NancyModule
    {
        public TestModule()
        {
            Get["/"] = parameters =>
                            {
                                var testModel = new TestModel {FirstName = "Nancy", LastName = "The super framework"};
                                return this.AutoFormatContent(testModel);
                            };
        }
    }
}