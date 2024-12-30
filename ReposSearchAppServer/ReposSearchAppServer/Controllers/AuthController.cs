using Microsoft.AspNetCore.Mvc;
using ReposSearchAppServer.Interfaces;

namespace ReposSearchAppServer.Controllers
{

    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authInterface;

        public AuthController(IAuthInterface authInterface)
        {
            _authInterface = authInterface;
        }

        [HttpGet("GetSecretKey")]
        public IActionResult GetSecretKey()
        {
            var token = _authInterface.GenerateJwtToken();

            return Ok(new { token = token });
        }
    }
}
