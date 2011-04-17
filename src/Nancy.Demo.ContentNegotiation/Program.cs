namespace Nancy.Demo.ContentNegotiation
{
    using System;
    using Hosting.Self;

    /// <summary>
    /// the only purpose of this bootstraper is to register the CustomResponder.
    /// </summary>
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void InitialiseInternal(TinyIoC.TinyIoCContainer container)
        {
            base.InitialiseInternal(container);
            container.Register(typeof(CustomResponder));
        }
    }

    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var nancyHost = new NancyHost(new Uri("http://localhost:1234/nancy/"), new Bootstrapper());
            
            nancyHost.Start();


            var message = string.Format("You can issue requests to http://localhost:1234/nancy/ with fiddler \n"
                       + "and use Content-Type 'text/xml' or 'text/json' and see the different responses. \n"
                       + "This demo also has a custom responder, if you use {0} you will see \n" 
                       + "a different xml version of the resource.", 
                       CustomResponder.MyCompanyMediaType);

            Console.WriteLine(message);
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }

   
}
