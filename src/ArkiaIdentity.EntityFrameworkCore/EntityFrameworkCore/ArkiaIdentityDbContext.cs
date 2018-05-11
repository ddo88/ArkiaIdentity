using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ArkiaIdentity.Authorization.Roles;
using ArkiaIdentity.Authorization.Users;
using ArkiaIdentity.MultiTenancy;
using Abp.IdentityServer4;

namespace ArkiaIdentity.EntityFrameworkCore
{
    public class ArkiaIdentityDbContext : AbpZeroDbContext<Tenant, Role, User, ArkiaIdentityDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */
        
        public ArkiaIdentityDbContext(DbContextOptions<ArkiaIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
    }
}
