using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ArkiaIdentity.Configuration;
using ArkiaIdentity.EntityFrameworkCore;
using ArkiaIdentity.Migrator.DependencyInjection;

namespace ArkiaIdentity.Migrator
{
    [DependsOn(typeof(ArkiaIdentityEntityFrameworkModule))]
    public class ArkiaIdentityMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ArkiaIdentityMigratorModule(ArkiaIdentityEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ArkiaIdentityMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ArkiaIdentityConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ArkiaIdentityMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
