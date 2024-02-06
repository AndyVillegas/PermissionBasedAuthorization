using Microsoft.AspNetCore.Mvc;
using PermissionBasedAuthorization.Services;

namespace PermissionBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public string Login(LoginRequest request)
        {
            return _authService.Login(request.Username, request.Password);
        }
    }
}
