using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ArkiaIdentity.Configuration;

namespace ArkiaIdentity.Web.Startup
{
    [DependsOn(typeof(ArkiaIdentityWebCoreModule))]
    public class ArkiaIdentityWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ArkiaIdentityWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<ArkiaIdentityNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ArkiaIdentityWebMvcModule).GetAssembly());
        }
    }
}
