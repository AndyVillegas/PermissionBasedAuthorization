using Microsoft.AspNetCore.Authorization;

namespace PermissionBasedAuthorization.Authentication
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionAttribute(string permission) :
            base(policy: permission)
        { }
    }
}
