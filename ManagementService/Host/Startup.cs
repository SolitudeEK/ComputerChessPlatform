using Management;
using Management.Proto;
using StorageManager;

namespace Host
{
    public class Startup
    {
        public const int PORT = 5001;
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(x => x.EnableDetailedErrors = true);
            services.AddGrpcReflection();
            services.AddSingleton<IManagement, Management.Management>();
            services.AddSingleton<IEngineStorage>(_ => new EngineStorage(Configuration.GetSection("engineConfigTemp").Value));
            services.AddSingleton<IEngineStorageAvl>(_ => new EngineStorage(Configuration.GetSection("engineConfig").Value));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGrpcService<ManagementService>();
                endpoints.MapGrpcReflectionService();
            });

        }

    }
}
