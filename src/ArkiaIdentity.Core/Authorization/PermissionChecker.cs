using Abp.Authorization;
using ArkiaIdentity.Authorization.Roles;
using ArkiaIdentity.Authorization.Users;

namespace ArkiaIdentity.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
