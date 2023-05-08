using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Host
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            Environment.CurrentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(Environment.OSVersion.ToString());
            IWebHost host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                    .UseKestrel(
                        options =>
                        {
                            options.ListenAnyIP(Startup.PORT, o => o.Protocols = HttpProtocols.Http1AndHttp2);
                        })
            .UseStartup<Startup>()
            .UseUrls($"http://*:{Startup.PORT}");

    }
}
