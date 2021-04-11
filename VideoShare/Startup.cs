using System;
using System.Threading;
using CorrelationId;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VideoShare.Infrastructure.Extensions;
using VideoShare.Infrastructure.Interfaces;
using VideoShare.Infrastructure.Logging;
using VideoShare.Infrastructure.Settings;
using VideoShare.Middlewares;

namespace VideoShare
{
    public class Startup
    {
        private readonly ProxySettings _proxySettings = new ProxySettings();

        public Startup(IConfiguration configuration)
        {
            configuration.BindConfigurationAndValidate(_proxySettings);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCorrelationId();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            //app.UseMiddleware<ProxyMiddleware>();
            app.UseRouting();
            app.UseCors(options => options.
                            AllowAnyOrigin().
                            AllowAnyHeader().
                            AllowAnyMethod());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(days: 0, hours: 0, minutes: 1, seconds: 30);
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProxySettings>(_proxySettings);
            services.AddCorrelationId();
            services.AddLogging().AddRouting(options => { options.LowercaseUrls = true; });
            services.AddOptions();
            services.AddSingleton(typeof(IExtendedLogger<>), typeof(ExtendedLogger<>));
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddCors();
            services.AddHttpClient();
            services.AddControllers();
        }
    }
}
