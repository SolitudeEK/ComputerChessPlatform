using EngineManagement;
using EngineManagement.Proto;
using EngineStorage;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Utils;

namespace Host
{
    public class Startup
    {
        public const int PORT = 5000;
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(x => x.EnableDetailedErrors = true);
            services.AddGrpcReflection();
            services.AddOptions();
            services.Configure<FileLocation>(Configuration.GetSection("FileLocation"));
            services.AddSingleton<IStorage, Storage>();
            services.AddScoped<IManager, Manager>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GameManagement>();
                endpoints.MapGrpcReflectionService();
            });

        }

    }
}
