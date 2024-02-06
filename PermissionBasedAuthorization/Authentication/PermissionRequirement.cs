using Microsoft.AspNetCore.Authorization;

namespace PermissionBasedAuthorization.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; set; }
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
