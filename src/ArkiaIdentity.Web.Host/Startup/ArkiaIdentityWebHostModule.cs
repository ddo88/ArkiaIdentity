using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ArkiaIdentity.Configuration;

namespace ArkiaIdentity.Web.Host.Startup
{
    [DependsOn(
       typeof(ArkiaIdentityWebCoreModule))]
    public class ArkiaIdentityWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ArkiaIdentityWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ArkiaIdentityWebHostModule).GetAssembly());
        }
    }
}
