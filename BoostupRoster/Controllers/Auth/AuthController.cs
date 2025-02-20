using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boostup.API.Controllers.Auth
{
    [ApiVersion(1)]
    [ApiVersion(2)]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger; 
        }


        [MapToApiVersion(1)]
        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Login Api Executed");
            return Ok("Login Successful from v1");
        }

        [MapToApiVersion(2)]
        [HttpGet]
        [Route("login")]
        public IActionResult Login_V2()
        {
            return Ok("Login Successful from v2");
        }
    }
}
