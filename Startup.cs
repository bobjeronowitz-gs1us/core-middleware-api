using AutoMapper;
using GS1US.Framework.API.Configuration;
using GS1US.Framework.API.DependencyInjection;
using GS1US.Framework.API.StartupSettings;
using GS1US.Framework.Common.Configuration.Apim;
using GS1US.Framework.Common.HttpNamedClients;
using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;

namespace GS1US.Framework.API
{
    public class Startup
    {
        private AppSettings appSettings;
        private IGS1USAppInsightsLogger appInsightsLogger { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup B2C Security
            var b2CSecurityTasks = new B2CSecurityTasks();
            var b2cSettings = GS1US.Framework.API.Security
                                .SecurityConfiguration
                                .Configure(services, this.Configuration, b2CSecurityTasks);

            // Setup Dependency Injection
            services.AddCommonServices()
                        .AddDataServices()
                        .AddDomainServices()
                        .AddControllerServices()
                        // Adds AutoMapper, it will configure all AutoMapper Profiles it finds in all assemblies (in Models folders)
                        .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ** Should Only Be Enabled for Debugging **
            IdentityModelEventSource.ShowPII = true;

            // gets back an object with appSettings properties
            appSettings = AppSettingsConfiguration.Configure(services, this.Configuration);

            // gets Apim settings from appSettings
            var apimSettings = ApimSettingsConfiguration.Configure(services, this.Configuration);

            // HttpClient Configuration
            HttpNamedClientConfiguration.Configure(services, apimSettings);

            services.AddCors(options =>
            {
                options.AddPolicy(appSettings.CorsPolicy,
                builder => builder.WithOrigins(appSettings.CorsOriginUrls)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });

            services.AddControllers();

            services.AddRouting(o =>
            {
                // clean lower-case...
                o.LowercaseUrls = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IGS1USAppInsightsLogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // configure the app insights logger
            AppInsightsLoggerConfiguration.Configure(this.appSettings, logger);
            app.UseHttpsRedirection();

            // Shows UseCors with named policy.            
            app.UseCors(appSettings.CorsPolicy);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
