using BuberDinner.Application.Features.Menus.Commands;
using BuberDinner.Contracts.Menu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;


namespace BuberDinner.Api.Controllers
{
    [Route("api/hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;

        private readonly ISender _sender;

        public MenusController(
            IMapper mapper,
            ISender sender
        )
        {
            _mapper = mapper;
            _sender = sender;
        }

        /// <summary>
        /// Create a new menu for a host
        /// </summary>
        /// <param name="hostId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMenu(string hostId, [FromBody] CreateMenuRequest request)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var menuCreated = await _sender.Send(command);

            var response = _mapper.Map<MenuResponse>(menuCreated);

            return Ok(response);
        }
    }
}
