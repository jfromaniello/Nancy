namespace Nancy.Demo.ContentNegotiation
{
    using System;
    using Hosting.Self;

    class Program
    {
        static void Main()
        {
            var nancyHost = new NancyHost(new Uri("http://localhost:1234/nancy/"));
            nancyHost.Start();

            var contentTypes = string.Join( "," ,new[] {"application/xml", "application/json", "text/xml", "text/json"});
            Console.WriteLine("You can issue requests to http://localhost:1234/nancy/ with fiddler and use Content-Type: {0} and see the different responses.", contentTypes);
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
