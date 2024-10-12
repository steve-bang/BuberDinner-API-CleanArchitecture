using BuberDinner.Application.Features.Auth.Commands;
using BuberDinner.Application.Features.Auth.Queries;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        private readonly IMapper _mapper;

        public AuthenticationController(
            ISender mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] BuberDinner.Contracts.Authentication.RegisterRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterCommand>(registerRequest);

            return Ok(
                await _mediator.Send(registerCommand)
            );
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] BuberDinner.Contracts.Authentication.LoginRequest loginRequest)
        {
            LoginQuery loginQuery = new LoginQuery
            {
                Email = loginRequest.Email,
                Password = loginRequest.Password
            };

            return Ok(
                await _mediator.Send(loginQuery)
            );
        }

    }
}