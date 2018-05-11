using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ArkiaIdentity.EntityFrameworkCore
{
    public static class ArkiaIdentityDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ArkiaIdentityDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ArkiaIdentityDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
