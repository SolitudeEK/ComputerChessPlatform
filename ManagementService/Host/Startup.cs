using Management;
using Microsoft.AspNetCore.Builder;
using StorageManager;

namespace Host
{
    public class Startup
    {
        public const int PORT = 5001;
        private readonly IConfiguration Configuration;
        private const string AllowOrigin = "front";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowOrigin,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000",
                                                          "*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  }); ;
            });
            services.AddSingleton<IManagement, Management.Management>();
            services.AddSingleton<IEngineStorage>(_ => new EngineStorage(Configuration.GetSection("engineConfigTemp").Value));
            services.AddSingleton<IEngineStorageAvl>(_ => new EngineStorage(Configuration.GetSection("engineConfig").Value));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors(AllowOrigin);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(AllowOrigin);
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

        }

    }
}
