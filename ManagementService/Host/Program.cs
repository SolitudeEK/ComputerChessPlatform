using Microsoft.AspNetCore;

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
                            options.ListenAnyIP(Startup.PORT);
                        })
            .UseStartup<Startup>()
            .UseUrls($"http://*:{Startup.PORT}");

    }
}
