using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Reflection;
using Utils;

namespace Host
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            IWebHost host = CreateWebHostBuilder(args).Build();
            Console.WriteLine("Service started");
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                    .UseKestrel(
                        options =>
                        {
                            options.ListenAnyIP(Startup.PORT, o => o.Protocols = HttpProtocols.Http2);
                        })
            .UseStartup<Startup>()
            .UseUrls($"http://*:{Startup.PORT}");

    }
}
