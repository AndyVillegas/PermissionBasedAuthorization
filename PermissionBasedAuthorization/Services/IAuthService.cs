namespace PermissionBasedAuthorization.Services
{
    public interface IAuthService
    {
        string Login(string username, string password);
    }
}