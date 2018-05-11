using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace ArkiaIdentity.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class ArkiaIdentityRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<ArkiaIdentityDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ArkiaIdentityRepositoryBase(IDbContextProvider<ArkiaIdentityDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="ArkiaIdentityRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class ArkiaIdentityRepositoryBase<TEntity> : ArkiaIdentityRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ArkiaIdentityRepositoryBase(IDbContextProvider<ArkiaIdentityDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
