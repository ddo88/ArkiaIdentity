using System.Collections.Generic;
using ArkiaIdentity.Roles.Dto;
using ArkiaIdentity.Users.Dto;

namespace ArkiaIdentity.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
