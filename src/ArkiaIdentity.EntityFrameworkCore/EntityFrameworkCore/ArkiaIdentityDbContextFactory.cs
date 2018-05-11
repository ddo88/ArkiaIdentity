using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ArkiaIdentity.Configuration;
using ArkiaIdentity.Web;

namespace ArkiaIdentity.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ArkiaIdentityDbContextFactory : IDesignTimeDbContextFactory<ArkiaIdentityDbContext>
    {
        public ArkiaIdentityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ArkiaIdentityDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ArkiaIdentityDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ArkiaIdentityConsts.ConnectionStringName));

            return new ArkiaIdentityDbContext(builder.Options);
        }
    }
}
