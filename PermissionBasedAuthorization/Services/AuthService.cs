using PermissionBasedAuthorization.Authentication;

namespace PermissionBasedAuthorization.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtProvider _jwtProvider;
        public static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "andyvillegas440@gmail.com",
                Username = "andy",
            },
            new User()
            {
                Id = 2,
                Email = "andyvillegas440@outlook.com",
                Username = "string",
            }
        };
        public AuthService(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }
        public string Login(string username, string password)
        {
            var user = users.First(u => u.Username == username);
            return _jwtProvider.Generate(user);
        }
    }
}
