namespace PermissionBasedAuthorization.Authentication
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}