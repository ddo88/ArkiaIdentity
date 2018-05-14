using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using ArkiaIdentity.Authentication.JwtBearer;
using ArkiaIdentity.Configuration;
using ArkiaIdentity.Identity;
using ArkiaIdentity.Web.Resources;
using ArkiaIdentity.Web.Configuration;
using Abp.IdentityServer4;
using ArkiaIdentity.Authorization.Users;
using Swashbuckle.AspNetCore.Swagger;

#if FEATURE_SIGNALR
using Owin;
using Abp.Owin;
using ArkiaIdentity.Owin;
#elif FEATURE_SIGNALR_ASPNETCORE
using Abp.AspNetCore.SignalR.Hubs;
#endif

namespace ArkiaIdentity.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            IdentityRegistrar.Register(services);
            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
               .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
               .AddInMemoryClients(IdentityServerConfig.GetClients())
               .AddAbpPersistedGrants<IAbpPersistedGrantDbContext>()
               .AddAbpIdentityServer<User>(); ;

            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

#if FEATURE_SIGNALR_ASPNETCORE
            services.AddSignalR();
#endif

            //
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "ArkiaIdentity API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);

                // Define the BearerAuth scheme that's in use
                //options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});
                //// Assign scope requirements to operations based on AuthorizeAttribute
                //options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            // Configure Abp and Dependency Injection
            return services.AddAbp<ArkiaIdentityWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseJwtTokenMiddleware();//("IdentityBearer");
            app.UseIdentityServer();

            //app.UseJwtTokenMiddleware();

#if FEATURE_SIGNALR
            // Integrate with OWIN
            app.UseAppBuilder(ConfigureOwinServices);
#elif FEATURE_SIGNALR_ASPNETCORE
            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });
#endif

            app.UseMvcWithDefaultRoute();
            
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "defaultWithArea",
            //        template: "{area}/{controller=Home}/{action=Index}/{id?}");

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }

#if FEATURE_SIGNALR
        private static void ConfigureOwinServices(IAppBuilder app)
        {
            app.Properties["host.AppName"] = "ArkiaIdentity";

            app.UseAbp();

            app.MapSignalR();
        }
#endif
    }
}
