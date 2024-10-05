using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] BuberDinner.Contracts.Authentication.RegisterRequest registerRequest)
        {
            return Ok(
                _authenticationService.Register(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password)
            );
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] BuberDinner.Contracts.Authentication.LoginRequest loginRequest)
        {
            return Ok(
                _authenticationService.Login(loginRequest.Email, loginRequest.Password)
            );
        }

    }
}