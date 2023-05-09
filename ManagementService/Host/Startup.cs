using System.Security.Claims;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Management;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
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
            services.AddLogging();
            services.AddKeycloakAuthentication(Configuration, KeycloakAuthenticationOptions.Section);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();
            services.AddAuthorization(o =>
            {
                o.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "app_admin"));
                o.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "app_user"));
            });
            services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, Array.Empty<string>()}
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowOrigin,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000",
                                                          "*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            services.AddSingleton<IManagement, Management.Management>();
            services.AddSingleton<IEngineStorage>(_ => new EngineStorage(Configuration.GetSection("engineConfigTemp").Value));
            services.AddSingleton<IEngineStorageAvl>(_ => new EngineStorage(Configuration.GetSection("engineConfig").Value));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors(AllowOrigin);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(AllowOrigin).RequireAuthorization("User");
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.UseHttpLogging();

        }

    }
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;
            if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "realm_access"))
            {
                var realmAccessClaim = claimsIdentity.FindFirst((claim) => claim.Type == "realm_access");
                var realmAccessAsDict = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(realmAccessClaim.Value);
                if (realmAccessAsDict["roles"] != null)
                {
                    foreach (var role in realmAccessAsDict["roles"])
                    {
                        Console.WriteLine(role);
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                }
            }

            return Task.FromResult(principal);
        }
    }
}
