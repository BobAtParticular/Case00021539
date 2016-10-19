using System;
using System.IO;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace Case00021539.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var configure = Configure.With();
            configure.Log4Net();
            configure.DefineEndpointName("Case00021539");
            configure.DefaultBuilder();
            configure.JsonSerializer();
            configure.InMemorySagaPersister();
            configure.UseInMemoryTimeoutPersister();
            configure.InMemorySubscriptionStorage();
            configure.MsmqTransport();


            var path = string.Empty;

            do
            {
                Console.WriteLine("Enter path to License file:");
                path = Console.ReadLine();
            } while (!File.Exists(path));

            configure.LicensePath(path);

            using (var startableBus = configure.UnicastBus().CreateBus())
            {
                var bus = startableBus.Start(() => configure.ForInstallationOn<Windows>().Install());
                Console.WriteLine("\r\nBus created and configured; press any key to stop program\r\n");
                Console.ReadKey();
            }
        }
    }
}
