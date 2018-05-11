using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ArkiaIdentity.Authorization;

namespace ArkiaIdentity
{
    [DependsOn(
        typeof(ArkiaIdentityCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ArkiaIdentityApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ArkiaIdentityAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ArkiaIdentityApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
